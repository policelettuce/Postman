using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRangeScript : MonoBehaviour
{

    public int RangeID;
    void OnTriggerEnter(Collider info)
    {

        string theName = info.transform.name;
        Debug.Log("Я бы прилип к этому " + theName);
        RangeID = int.Parse(theName);

    }
}
