using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomManager : MonoBehaviour
{
    public int boostRandomRange;
    public float boostGap;

    public int walkerRandomRange;
    public float walkerGap;

    private void Start()
    {
        boostRandomRange = 100;
        boostGap = 4;

        walkerRandomRange = 500;
        walkerGap = 4;
    }

    public bool spawnBoost()
    {
        int value = Random.Range(0, boostRandomRange);
        Debug.Log("RandomRange for boost is " + value);
        if (value <= 20)
        {
            PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
            boostRandomRange += Mathf.RoundToInt(50 * move.speed);
            boostGap = 4;

            return true;
        }
        else
        {
            boostRandomRange -= Mathf.RoundToInt(boostGap);
            boostGap *= 1.15f;

            return false;
        }
    }

    public bool spawnWalker()
    {
        int value = Random.Range(0, boostRandomRange);
        Debug.Log("RandomRange for walker is " + value);
        if (value <= 25)
        {
            PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
            walkerRandomRange += Mathf.RoundToInt(20 * move.speed);
            walkerGap = 4;

            return true;
        }
        else
        {
            walkerRandomRange -= Mathf.RoundToInt(walkerGap);
            walkerGap *= 1.15f;

            return false;
        }
    }
}
