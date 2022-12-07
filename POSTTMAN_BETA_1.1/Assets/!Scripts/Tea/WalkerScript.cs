using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerScript : MonoBehaviour
{

    public Push push;
    public FrontPush frontpush;
    public GameObject walkerTag;
    public BoxCollider collider;
    public GameObject attention;
    public GameObject Beep;

    private Player player;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Signal")
        {
            AudioSource audio = Beep.GetComponent<AudioSource>();
            audio.Play();
            Debug.Log("Съебался в ужасе");
            push.enabled = true;
            Destroy(this);
            Destroy(walkerTag);
            collider.enabled = false;
            attention.SetActive(false);
            player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            player.totalevades++;

            if (player.isTutoralCompleted == false)
            {
                Tutorial tutorial = GameObject.FindWithTag("GameManager").GetComponent<Tutorial>();
                tutorial.PeopleCount();
            }
        }

        if (coll.tag == "Van")
        {
            player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            player.totalcrashes++;
            player.onGameEnd();
            frontpush.enabled = true;
            Destroy(this);
            Destroy(walkerTag);
            attention.SetActive(false);
        }

        if (coll.tag == "Warning")
        {
            attention.SetActive(true);
        }
    }

    public void Destroy()
    {
        push.enabled = true;
        Destroy(this);
        Destroy(walkerTag);
    }
}
