using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Madness : MonoBehaviour
{
    private bool active;
    private bool godmodeCheck;

    public float madnessDruation;

    private GameObject[] roadblocks;

    public GameObject upgradeButton;
    public Text priceText;

    public int upgradeCount;

    private float startTime;

    void Start()
    {
        active = false;
        godmodeCheck = false;
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            if (Time.fixedTime > startTime + madnessDruation)
            {
                SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
                spawner.updateMadness(false);

                roadblocks = GameObject.FindGameObjectsWithTag("Roadblock");
                godmodeCheck = true;
                active = false;
                Debug.Log("first cycle");
            }
        }

        if (godmodeCheck == true)
        {
            if (roadblocks[2] == null)
            {
                Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
                player.isInMadness = false;
                SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
                spawner.spawn = true;
                godmodeCheck = false;
                Debug.Log("Godmode disabled!");
            }
        }
    }

    public void Activate()
    {
        startTime = Time.fixedTime;
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateMadness(true);
        spawner.spawn = false;
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        player.isInMadness = true;
        active = true;
    }

    public void buyUpgrade()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        int cost = shop.getBoostUpgradeCost(upgradeCount);
        if (player.money > cost)
        {
            madnessDruation += 2;
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
        madnessDruation += 1;
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
