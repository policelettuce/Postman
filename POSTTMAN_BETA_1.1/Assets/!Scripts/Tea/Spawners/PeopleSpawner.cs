using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    public GameObject[] people;

    private SpawnerManager spawnerManager;

    void Start()
    {
        spawnerManager = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        Tutorial tutorial = GameObject.FindWithTag("GameManager").GetComponent<Tutorial>();
        if (spawnerManager.spawn == true && spawnerManager.peopleSpawn == true)
        {
            spawnNormal();
        }
        else if (tutorial.forcePeopleSpawn == true)
        {
            forceSpawn();
        }
        else
        {
            spawnNothing();
        }
    }

    public void spawnNormal()
    {
        RandomManager random = GameObject.FindWithTag("GameManager").GetComponent<RandomManager>();
        if (random.spawnWalker() == true)
        {
            int rand = Random.Range(0, people.Length);
            for (int i = 0; i < people.Length; i++)
            {
                if (rand != i)
                {
                    GameObject.Destroy(people[i]);
                }
            }
        }
        else
        {
            spawnNothing();
        }
    }

    public void forceSpawn()
    {
        int rand = Random.Range(0, people.Length);
        for (int i = 0; i < people.Length; i++)
        {
            if (rand != i)
            {
                GameObject.Destroy(people[i]);
            }
        }
    }

    public void spawnNothing()
    {
        for (int i = 0; i < people.Length; i++)
        {
            GameObject.Destroy(people[i]);
        }
    }
}
