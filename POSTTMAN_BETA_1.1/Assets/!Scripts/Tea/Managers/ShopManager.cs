using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject TruckShop;
    public GameObject PropShop;
    public Button carButton;
    public Button propButton;

    public int[] isBoughtCars;
    public int[] isBoughtProps;

    public Sprite isChosen;
    public Sprite canChoose;
    public Sprite canBuy;
    public Sprite cannotBuy;

    public Text price;
    public Text NameOf;

    public void loadArray(int[] arrayCars, int[] arrayProps)
    {
        isBoughtCars = arrayCars;
        isBoughtProps = arrayProps;
    }

    public int getHealthUpgradeCost(int updamt)
    {
        if (updamt == 0) { return 10000; }
        if (updamt == 1) { return 30000; }
        if (updamt == 2) { return 61000; }
        if (updamt == 3) { return 101000; }
        if (updamt == 4) { return 250001; }
        return 666;
    }

    public int getBoostUpgradeCost(int updamt)
    {
        if (updamt == 0) { return 1000; }
        if (updamt == 1) { return 5000; }
        if (updamt == 2) { return 9999; }
        if (updamt == 3) { return 22500; }
        if (updamt == 4) { return 888888; }
        if (updamt == 5) { return 99999; }
        return 666;
    }

    public void defineShop(int id)
    {
        if (TruckShop.activeInHierarchy == true)
        {
            updateTruckShop(id);
            ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
            culling.truckShopActive = true;
        }
        else if (PropShop.activeInHierarchy == true)
        {
            updatePropShop(id);
            ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
            culling.truckShopActive = false;
        }
    }

    public void updateTruckShop(int id)
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        if (player.carID == id)
        {
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfCar(id));
            price.enabled = false;
            carButton.interactable = false;
            carButton.GetComponent<Image>().sprite = isChosen;
        }
        else if (isBoughtCars[id] == 1)
        {
            price.enabled = false;
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfCar(id));
            carButton.interactable = true;
            carButton.GetComponent<Image>().sprite = canChoose;
        }
        else if (player.money > getCarPrice(id))
        {
            price.enabled = true;
            carButton.interactable = true;
            price.text = ("" + getCarPrice(id));
            NameOf.text = ("" + getNameOfCar(id));
            carButton.GetComponent<Image>().sprite = canBuy;
        }
        else
        {
            price.enabled = true;
            carButton.interactable = false;
            price.text = ("" + getCarPrice(id));
            NameOf.text = ("" + getNameOfCar(id));
            carButton.GetComponent<Image>().sprite = cannotBuy;
        }
    }

    public int getCarPrice(int id)
    {
        if (id == 0) { return 0; }
        if (id == 1) { return 5000; }
        if (id == 2) { return 25000; }
        if (id == 3) { return 49000; }
        if (id == 4) { return 120000; }
        if (id == 5) { return 280000; }
        if (id == 6) { return 500000; }
        return 666;
    }

    public void updatePropShop(int id)
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        if (player.isChosen[id] == 1)
        {
            price.enabled = false;
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfProp(id));
            propButton.interactable = true;
            propButton.GetComponent<Image>().sprite = isChosen;
        }
        else if (isBoughtProps[id] == 1)
        {
            price.enabled = false;
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfProp(id));
            propButton.interactable = true;
            propButton.GetComponent<Image>().sprite = canChoose;
        }
        else if (player.money > getPropPrice(id))
        {
            price.enabled = true;
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfProp(id));
            propButton.interactable = true;
            price.text = ("" + getPropPrice(id));
            propButton.GetComponent<Image>().sprite = canBuy;
        }
        else
        {
            price.enabled = true;
            NameOf.enabled = true;
            NameOf.text = ("" + getNameOfProp(id));
            propButton.interactable = false;
            price.text = ("" + getPropPrice(id));
            propButton.GetComponent<Image>().sprite = cannotBuy;
        }
    }

    public int getPropPrice(int id)
    {
        if (id == 0) { return 0; }
        if (id == 1) { return 1000; }
        if (id == 2) { return 2500; }
        if (id == 3) { return 5000; }
        if (id == 4) { return 10000; }
        if (id == 5) { return 20000; }
        if (id == 6) { return 50000; }
        if (id == 7) { return 100000; }
        if (id == 8) { return 200000; }
        if (id == 9) { return 501337; }
        return 666;
    }

    public string getNameOfCar(int id)
    {
        if (id == 0) { return "PICKUP"; }
        if (id == 1) { return "MINIBUS"; }
        if (id == 2) { return "GRANDPA'S CAR"; }
        if (id == 3) { return "POLICE"; }
        if (id == 4) { return "BENZTRUCK"; }
        if (id == 5) { return "HOUSE ON WHEELS"; }
        if (id == 6) { return "BIG TRUCK"; }
        return "SUPERCAR";
    }

    public string getNameOfProp(int id)
    {
        if (id == 0) { return "SECRET GIFT"; }
        if (id == 1) { return "FULL ATM"; }
        if (id == 2) { return "DANGEROUS BOMB"; }
        if (id == 3) { return "BOX WITH ..."; }
        if (id == 4) { return "ARCADE MACHINE"; }
        if (id == 5) { return "ZOMBIE VIRUS"; }
        if (id == 6) { return "COMFORTABLE SOFA"; }
        if (id == 7) { return "OFFICE COOLER"; }
        if (id == 8) { return "4K TV"; }
        if (id == 9) { return "GOLDEN TOILET"; }
        return "SUPERPROP";
    }

}
