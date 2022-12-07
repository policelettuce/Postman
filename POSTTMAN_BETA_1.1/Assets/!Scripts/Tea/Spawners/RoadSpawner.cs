using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject[] RoadBlockPrfbs;
    public GameObject StartBlock;

    float blockZPos = 0;
    public int blocksCount = 7;
    float blockLength = 0;
    public int SafeZone;
    public Transform PlayerTransf;
    List<GameObject> CurrentBlocks = new List<GameObject>();
    
    void Start()
    {
        blockZPos = StartBlock.transform.position.z;
        blockLength = StartBlock.GetComponent<BoxCollider>().bounds.size.z;

        for (int i = 0; i< blocksCount; i++)
        {
            SpawnBlock();
        }
    }

    
    void Update()
    {
        CheckForSpawn();
    }

    void CheckForSpawn() {
        if(PlayerTransf.position.z - SafeZone > (blockZPos - blocksCount * blockLength))
        {
            SpawnBlock();
            DestroyBlock();
        }
    }


    void SpawnBlock() {
        GameObject block = Instantiate(RoadBlockPrfbs[Random.Range(0, RoadBlockPrfbs.Length)], transform);
        blockZPos += blockLength;
        block.transform.position = new Vector3(0, 0, blockZPos);
        CurrentBlocks.Add(block);
    }

    void DestroyBlock()
    {
        Destroy(CurrentBlocks[0]);
        CurrentBlocks.RemoveAt(0);
    }
}
