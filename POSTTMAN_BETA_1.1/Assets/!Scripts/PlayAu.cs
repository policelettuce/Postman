using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAu : MonoBehaviour
{

    public GameObject audi;

    void Start()
    {

        audi.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "walker")
        {
            audi.SetActive(true);

        }


    }

    
    void OnTriggerExit(Collider other)
    {

        if (other.tag == "walker")
        {
            audi.SetActive(false);

        }

    }
}
