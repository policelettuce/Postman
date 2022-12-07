using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    public bool spawn;
    public bool peopleSpawn;
    public bool madness;
    public bool boostSpawn;

    public GameObject[] markers;
    private int markersCount;
    public GameObject[] boosts;
    private int boostsCount;
    public GameObject[] people;
    private int peopleCount;

    private void Start()
    {
        spawn = false;
        madness = false;
    }

    public void updateSpawn(bool update)
    {
        spawn = update;
        if (spawn == false)
        {
            destroyAllMarkers();
            destroyAllBoosts();
            destroyPeople();
        }
    }

    public void updatePeopleSpawn(bool update)
    {
        peopleSpawn = update;
        if (peopleSpawn == false)
        {
            destroyPeople();
        }
    }

    public void updateMadness(bool update)
    {
        madness = update;
        if (madness == true)
        {
            madnessMarkers();
            destroyAllBoosts();
            destroyPeople();
        }
    }

    public void destroyAllMarkers() 
    {
        markersCount = GameObject.FindGameObjectsWithTag("Marker").Length;
        markers = new GameObject[markersCount];
        markers = GameObject.FindGameObjectsWithTag("Marker");
        for (int i = 0; i < markers.Length; i++)
        {
            Destroy(markers[i]);
        }
    }

    public void destroyAllBoosts()  
    {
        boostsCount = GameObject.FindGameObjectsWithTag("Boost").Length;
        if (boostsCount > 0)
        {
            boosts = new GameObject[boostsCount];
            boosts = GameObject.FindGameObjectsWithTag("Boost");
            for (int i = 0; i < boosts.Length; i++)
            {
                GameObject boost = boosts[i].transform.parent.gameObject;
                Destroy(boost);
            }
        }
    }

    public void destroyPeople()
    {
        peopleCount = GameObject.FindGameObjectsWithTag("walker").Length;
        if (peopleCount > 0)
        {
            people = new GameObject[peopleCount];
            people = GameObject.FindGameObjectsWithTag("walker");
            for (int i = 0; i < people.Length; i++)
            {
                WalkerScript walker = people[i].GetComponentInParent<WalkerScript>();
                walker.Destroy();
            }
        }
    }

    public void madnessMarkers()
    {
        markersCount = GameObject.FindGameObjectsWithTag("Marker").Length;
        markers = new GameObject[markersCount];
        markers = GameObject.FindGameObjectsWithTag("Marker");
        for (int i = 0; i < markers.Length; i++)
        {
            Destroy(markers[i]);
        }
        GameObject[] roadblocks = GameObject.FindGameObjectsWithTag("Roadblock");
        for (int i = 0; i < roadblocks.Length; i++)
        {
            MarkerSpawner spawner = roadblocks[i].GetComponent<MarkerSpawner>();
            spawner.spawnAllMarkers();
        }
    }
}
