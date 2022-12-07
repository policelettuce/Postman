using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanCollideScript : MonoBehaviour
{

    private bool flag = false;
    private Player playerReference;

    private void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Van" && flag == false)
        {
            playerReference = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            playerReference.markerMiss();
            Debug.Log("passed through!");
            flag = true;
        }
    }
}
