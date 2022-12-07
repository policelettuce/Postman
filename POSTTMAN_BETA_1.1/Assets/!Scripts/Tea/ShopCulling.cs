using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCulling : MonoBehaviour
{
    public bool truckShopActive;
    public GameObject[] cars;
    public GameObject[] props;

    public void Culling(int id)
    {
        if (truckShopActive == true)
        {
            int prev = id - 1;
            if (prev < 0) { prev = 0; }
            int next = id + 1;
            if (next > cars.Length) { next = cars.Length; }

            for (int i = 0; i < cars.Length; i++)
            {
                if (i != prev && i != id && i != next)
                {
                    cars[i].SetActive(false);
                }
                else { cars[i].SetActive(true); }
            }
        }

        else
        {
            int prev = id - 1;
            if (prev < 0) { prev = 0; }
            int next = id + 1;
            if (next > props.Length) { next = props.Length; }

            for (int i = 0; i < props.Length; i++)
            {
                if (i != prev && i != id && i != next)
                {
                    props[i].SetActive(false);
                }
                else { props[i].SetActive(true); }
            }
        }
    }
}
