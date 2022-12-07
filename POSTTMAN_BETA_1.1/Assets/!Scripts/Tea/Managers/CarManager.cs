using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public GameObject[] Cars;
    public int carID;

    public int[] isBought;

    public GameObject scrolling;
    public GameObject Snd;

    public void loadCar(int loadedID, int[] boughtarray)
    {
        isBought = boughtarray;
        carID = loadedID;
        for (int i = 0; i < Cars.Length; i++)
        {
            if (i == carID)
            {
                Cars[i].SetActive(true);
            }
            else
            {
                Cars[i].SetActive(false);
            }
        }
    }

    public void selectOrBuy()
    {
        GetID id = scrolling.GetComponent<GetID>();
        carID = id.seID1;
        if (isBought[carID] == 1)
        {
            selectCar();
        }
        else if (isBought[carID] == 0)
        {
            buyCar();
        }
    }

    public void selectCar()
    {
        for (int i = 0; i < Cars.Length; i++)
        {
            if (i == carID)
            {
                Cars[i].SetActive(true);
            }
            else
            {
                Cars[i].SetActive(false);
            }
        }
    }

    public void buyCar()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        if (player.money > shop.getCarPrice(carID))
        {
            player.money -= shop.getCarPrice(carID);
            isBought[carID] = 1;
            selectCar();
            AudioSource audio = Snd.GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
