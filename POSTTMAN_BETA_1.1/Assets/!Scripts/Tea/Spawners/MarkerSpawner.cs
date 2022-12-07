using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerSpawner : MonoBehaviour
{
    public Transform[] markerPos;
    public GameObject markerLeft;
    public GameObject markerRight;
    public GameObject markerMadness;
    public GameObject[] boosts;

    private GameObject clone;

    private SpawnerManager spawnerManager;

    public int boostSpawnProbability;

    public void Start()
    {
        spawnerManager = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        if (spawnerManager.madness == true)
        {
            spawnAllMarkers();
        }
        else if (spawnerManager.spawn == true)
        {
            spawnNormal();
        }
        else if (GameObject.FindWithTag("GameManager").GetComponent<Tutorial>().forceBoostSpawn == true)
        {
            forceSpawnBoost();
        }
    }

    public void spawnNormal()
    {
        int position = Random.Range(0, markerPos.Length); //left or right marker

        if (markerPos[position].position.x < 0)
        {
            clone = Instantiate(markerLeft);
            clone.transform.SetParent(this.transform);
            clone.transform.position = markerPos[position].position;
        }
        else
        {
            clone = Instantiate(markerRight);
            clone.transform.SetParent(this.transform);
            clone.transform.position = markerPos[position].position;
        }

        RandomManager randman = GameObject.FindWithTag("GameManager").GetComponent<RandomManager>();
        if (randman.spawnBoost() == true && spawnerManager.boostSpawn == true)
        {
            spawnBoost(position);
        }
    }

    public void spawnBoost(int position)   //called from spawnNormal func
    {
        int boostpos = Random.Range(0, markerPos.Length);   //determine boost position
        while (boostpos == position)
        {
            boostpos = Random.Range(0, markerPos.Length);
        }

        Bassdrop bassdrop = GameObject.FindWithTag("GameManager").GetComponent<Bassdrop>();
        Doublemoney doublemoney = GameObject.FindWithTag("GameManager").GetComponent<Doublemoney>();

        int randboost = Random.Range(0, boosts.Length);               //here you can choose which boost will be spawning. default string: Random.Range(0, boosts.Length);

        if (randboost == 0 && bassdrop.buttonActive && !doublemoney.active)   //check random value to not spawn same boosts
        {
            Debug.Log("bassdrop active, doublemoney inactive, cant spawn 0th");
            while (randboost == 0)
            {
                randboost = Random.Range(0, boosts.Length);
            }
        }
        else if (randboost == 2 && !bassdrop.buttonActive && doublemoney.active)
        {
            Debug.Log("bassdrop inactive, doublemoney active, cant spawn 2nd");
            while (randboost == 2)
            {
                randboost = Random.Range(0, boosts.Length);
            }
        }
        else if ((randboost == 0 || randboost == 2) && bassdrop.buttonActive && doublemoney.active)
        {
            Debug.Log("bassdrop active, doublemoney active, cant spawn 0th and 2nd");
            while (randboost == 0 || randboost == 2)
            {
                randboost = Random.Range(0, boosts.Length);
            }
        }

        clone = Instantiate(boosts[randboost]);
        clone.transform.SetParent(this.transform);
        clone.transform.position = markerPos[boostpos].position;
    }

    public void spawnAllMarkers()
    {
        for (int i = 0; i < markerPos.Length; i++)
        {
            clone = Instantiate(markerMadness);
            clone.transform.SetParent(this.transform);
            clone.transform.position = markerPos[i].position;
        }
    }

    public void forceSpawnBoost()
    {
        int boostpos = Random.Range(0, markerPos.Length);
        int randboost = 1;

        clone = Instantiate(boosts[randboost]);
        clone.transform.SetParent(this.transform);
        clone.transform.position = markerPos[boostpos].position;
    }
}
