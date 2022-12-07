using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEnterExit : MonoBehaviour
{
    public GameObject RoadSpwnr;
    public GameObject ShopEng;
    public GameObject MainInterface;
    public GameObject TruckShop;
    public GameObject PropShop;
    public GameObject TruckChooseButton;
    public GameObject PropChooseButton;
    public GameObject Settingss;
    public GameObject BoostShop;
    public GameObject MoneyCountCanvas;
    public GameObject AchivMenu;

    public Button truckShopButton;
    public Button propShopButton;

    public bool isTruckShopActive;

    public bool isADShown;

    void Start()
    {
        isTruckShopActive = true;
        ShopEng.SetActive(false);
        TruckChooseButton.SetActive(false);
        PropChooseButton.SetActive(false);
        Settingss.SetActive(false);
        BoostShop.SetActive(false);
        MoneyCountCanvas.SetActive(true);
        AchivMenu.SetActive(false);
    }
    
    public void ShopEnter()
    {
        TruckChooseButton.SetActive(true);
        MainInterface.SetActive(false);
        PropShop.SetActive(false);
        ShopEng.SetActive(true);
        MoneyCountCanvas.SetActive(false);
        MoneyCountCanvas.SetActive(true);
        RoadSpwnr.SetActive(false);

        if (isTruckShopActive == true) { OpenTruckShop(); }
        else { OpenPropShop(); }

    }

    public void ShopExit()
    {
        if (isADShown == false)
        {
            isADShown = true;
            GameObject.FindWithTag("GameManager").GetComponent<AdsManager>().ShowInterstitial();
        }
        MainInterface.SetActive(true);
        ShopEng.SetActive(false);
        RoadSpwnr.SetActive(true);
    }

    public void OpenTruckShop()
    {
        TruckShop.transform.localPosition = new Vector3(-0.63f, 0.06f, 0.3f);
        PropChooseButton.SetActive(false);
        TruckChooseButton.SetActive(true);
        TruckShop.SetActive(true);
        PropShop.SetActive(false);
        ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
        culling.Culling(0);

        propShopButton.interactable = true;
        truckShopButton.interactable = false;
        isTruckShopActive = true;
    }

    public void OpenPropShop()
    {
        PropShop.transform.localPosition = new Vector3(-1f, 0, 0.4f);
        TruckChooseButton.SetActive(false);
        PropChooseButton.SetActive(true);
        PropShop.SetActive(true);
        TruckShop.SetActive(false);
        ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
        culling.Culling(0);

        propShopButton.interactable = false;
        truckShopButton.interactable = true;
        isTruckShopActive = false;
    }

    public void SettingsEnter()
    {
        MainInterface.SetActive(false);
        Settingss.SetActive(true);
        MoneyCountCanvas.SetActive(false);
        MoneyCountCanvas.SetActive(true);

    }

    public void SettingsExit()
    {
        MainInterface.SetActive(true);
        Settingss.SetActive(false);
    }

    public void BoostEnter()
    {
        MainInterface.SetActive(false);
        BoostShop.SetActive(true);
        MoneyCountCanvas.SetActive(false);
        MoneyCountCanvas.SetActive(true);
        RoadSpwnr.SetActive(false);

    }

    public void BoostExit()
    {
        if (isADShown == false)
        {
            isADShown = true;
            GameObject.FindWithTag("GameManager").GetComponent<AdsManager>().ShowInterstitial();
        }
        MainInterface.SetActive(true);
        BoostShop.SetActive(false);
        RoadSpwnr.SetActive(true);
    }

    public void AchivEnter()
    {
        MainInterface.SetActive(false);
        AchivMenu.SetActive(true);
        RoadSpwnr.SetActive(false);
    }

    public void AchivExit()
    {
        MainInterface.SetActive(true);
        RoadSpwnr.SetActive(true);
        AchivMenu.SetActive(false);
    }
}
