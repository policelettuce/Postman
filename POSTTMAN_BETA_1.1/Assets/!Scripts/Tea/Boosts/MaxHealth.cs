using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHealth : MonoBehaviour
{
    public GameObject upgradeButton;
    public Text priceText;

    public int upgradeCount;
    public bool buttonActive;

    public int hpboost;

    public void buyUpgrade()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        int cost = shop.getHealthUpgradeCost(upgradeCount);
        if (player.money > cost)
        {
            hpboost += 1;
            if (upgradeCount < 4)
            {
                upgradeCount++;
                priceText.text = ("" + shop.getHealthUpgradeCost(upgradeCount));
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
        hpboost += 1;
        if (upgradeCount < 4)
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
        priceText.text = ("" + shop.getHealthUpgradeCost(amt));
    }
}
