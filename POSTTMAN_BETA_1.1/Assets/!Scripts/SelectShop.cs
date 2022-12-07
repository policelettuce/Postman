using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectShop : MonoBehaviour
{
    public GameObject[] Prefabs;
    private GameObject Choose;
    public GameObject Scr;
    private int ID;
    public GameObject prnt;

    public void Sel() {
        Choose = Prefabs[ID];
        for(int i = 0; i < Prefabs.Length; i++)
        {
            if (i != ID)
            {
                Prefabs[i].SetActive(false);
            }
            else
            {
                Prefabs[i].SetActive(true);
            }
        }
    }
}
