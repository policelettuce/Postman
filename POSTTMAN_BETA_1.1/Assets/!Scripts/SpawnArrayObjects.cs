using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnArrayObjects : MonoBehaviour
{
    
    public GameObject[] ObjPrefabs;
    public float ObjOffset; 
    public int seID;


    void Start()
    {

        
        for (int i = 0; i < ObjPrefabs.Length; i++)
        {
            
            Instantiate(ObjPrefabs[i], transform);
            if (i == 0) continue;

            ObjPrefabs[i].transform.localPosition = new Vector3(ObjPrefabs[i - 1].transform.localPosition.x + ObjOffset, ObjPrefabs[1].transform.localPosition.y, ObjPrefabs[i-1].transform.localPosition.z);
            
        }
    }
    void Update()
    {
        
    }
}