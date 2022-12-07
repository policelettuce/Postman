using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizingShop : MonoBehaviour
{

    private MeshRenderer truck;
    private GameObject truckdisable;


    void OnTriggerEnter(Collider info)
    {

        string eName = "van" + info.transform.name;
        Debug.Log("Появляйся бля " + eName);
        GameObject.FindWithTag(eName).GetComponent<MeshRenderer>().enabled = true;
        
    }

    void OnTriggerExit(Collider info)
    {

        string eName = "van" + info.transform.name;
        Debug.Log("Уходи " + eName);
        GameObject.FindWithTag(eName).GetComponent<MeshRenderer>().enabled = false;
    }
}
