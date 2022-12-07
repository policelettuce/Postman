using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{

    public void defineBoost(string tag)
    {
        if (tag == "boostBassdrop") { Bassdrop(); }
        if (tag == "boostBoost") { Boost(); }
        if (tag == "boostDoublemoney") { Doublemoney(); }
        if (tag == "boostHealth") { Health(); }
        if (tag == "boostMadness") { Madness(); }
    }

    void Bassdrop()
    {
        Debug.Log("picked up bassdrop");
        Bassdrop bassdrop = GameObject.FindWithTag("GameManager").GetComponent<Bassdrop>();
        bassdrop.ActivateButton();
    }

    void Boost()
    {
        Debug.Log("picked up boost");
        Boost boost = GameObject.FindWithTag("GameManager").GetComponent<Boost>();
        boost.Activate();
    }

    void Doublemoney()
    {
        Debug.Log("picked up doublemoney");
        Doublemoney doublemoney = GameObject.FindWithTag("GameManager").GetComponent<Doublemoney>();
        doublemoney.Activate();
    }

    void Health()
    {
        Debug.Log("picked up helath");
        Health health = GameObject.FindWithTag("GameManager").GetComponent<Health>();
        health.Activate();
    }

    void Madness()
    {
        Debug.Log("picked up madness");
        Madness madness = GameObject.FindWithTag("GameManager").GetComponent<Madness>();
        madness.Activate();
    }
}
