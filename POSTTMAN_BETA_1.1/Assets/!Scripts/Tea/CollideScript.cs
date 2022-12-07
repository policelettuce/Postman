using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideScript : MonoBehaviour
{
    private bool flag = false;
    private float startTime;
    private float timeDelta;

    private GameObject van;
    private float speed;
    private float pause;

    private Player playerReference;

    private BoostManager boostManagerReference;

    private Tutorial tutorial;

    private void Start()
    {
        startTime = Time.fixedTime;
        playerReference = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        boostManagerReference = GameObject.FindWithTag("GameManager").GetComponent<BoostManager>();
        tutorial = GameObject.FindWithTag("GameManager").GetComponent<Tutorial>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Marker" && flag == false)
        {
            GameObject Marker = coll.gameObject;
            GameObject MarkerParent = Marker.transform.parent.gameObject;
            flag = true;
            playerReference.markerHit();
            Debug.Log("hit!");
            playerReference.HitSound();
            Destroy(MarkerParent.gameObject);
            playerReference.totalmarkers++;

            if (!playerReference.isTutoralCompleted)
            {
                tutorial.MarkerCount();
            }
        }
        else if (coll.tag == "afterMarker" && flag == false)
        {
            GameObject Marker = coll.gameObject;
            GameObject MarkerParent = Marker.transform.parent.gameObject;
            flag = true;
            playerReference.markerMiss();
            Debug.Log("miss (near marker)!");
            Destroy(MarkerParent.gameObject);
        }
        else if (coll.tag == "Boost" && flag == false)
        {
            GameObject boostCollider = coll.gameObject;
            GameObject boost = boostCollider.transform.parent.gameObject;
            flag = true;
            boostManagerReference.defineBoost(boost.tag);
            Debug.Log("hit boost!");
            playerReference.totalboosts++;

            if (!playerReference.isTutoralCompleted)
            {
                tutorial.continueCount();
            }
            Destroy(boost.gameObject);
        }
    }

    private void Update()
    {
        if (flag == false)
        {
            van = GameObject.FindWithTag("Van");
            PlayerMove move = van.GetComponent<PlayerMove>();
            speed = move.speed;
            pause = speed * 0.1f;

            if (pause < 0.3)
            {
                pause = 0.3f;
            }
        }

        timeDelta = Time.fixedTime - startTime;
        if (timeDelta > pause && flag == false)
        {
            playerReference.markerMiss();
            Debug.Log("miss!");
            flag = true;
        }
    }
}


