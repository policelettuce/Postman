using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doublemoney : MonoBehaviour
{
    public float multiplierDuration;
    private float startTime;

    public GameObject upgradeButton;
    public Text priceText;

    public int upgradeCount;

    public bool active;

    void Start()
    {
        active = false;
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            if (Time.fixedTime > startTime + multiplierDuration)
            {
                Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
                player.moneyMultiplier /= 2;
                active = false;
            }
        }
    }

    public void Activate()
    {
        startTime = Time.fixedTime;
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        player.moneyMultiplier *= 2;
        active = true;
    }

    public void buyUpgrade()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        int cost = shop.getBoostUpgradeCost(upgradeCount);
        if (player.money > cost)
        {
            multiplierDuration += 2;
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
        multiplierDuration += 2;
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
