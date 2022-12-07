using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bassdrop : MonoBehaviour
{
    public float bassdropDuration;
    private float startTime;

    public GameObject bassdropButton;
    public GameObject upgradeButton;
    public Text priceText;

    public int upgradeCount;
    private bool active;
    public bool buttonActive;

    private void Start()
    {
        active = false;
        buttonActive = false;
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            if (Time.fixedTime > startTime + bassdropDuration)
            {
                SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
                spawner.updatePeopleSpawn(true);
                active = false;
                buttonActive = false;
            }
        }
    }

    public void Activate()
    {
        startTime = Time.fixedTime;
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updatePeopleSpawn(false);
        active = true;
        bassdropButton.SetActive(false);
    }

    public void ActivateButton()
    {
        bassdropButton.SetActive(true);
        buttonActive = true;
    }

    public void buyUpgrade()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        int cost = shop.getBoostUpgradeCost(upgradeCount);
        if (player.money > cost)
        {
            bassdropDuration += 2;
            if (upgradeCount < 5)
            {
                upgradeCount++;
                priceText.text = ("" + shop.getBoostUpgradeCost(upgradeCount));
            }
            else
            {
                upgradeCount++;
                upgradeButton.SetActive(false);
            }
            player.money -= cost;
        }

        else
        {
            Debug.Log("Not enough money!");
        }
    }

    public void Upgrade()
    {
        bassdropDuration += 2;
        if (upgradeCount < 5)
        {
            upgradeCount++;
        }
        else
        {
            upgradeCount++;
            upgradeButton.SetActive(false);
        }
    }

    public void loadUpgrade(int amt)
    {
        for (int i = 0; i < amt; i++)
        {
            Upgrade();
        }

        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();
        priceText.text = ("" + shop.getBoostUpgradeCost(amt));
    }
}
