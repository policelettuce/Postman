using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public float boostDuration;
    public float boostMaxspeed;
    public float boostAcceleration;
    private float startTime;

    public GameObject upgradeButton;
    public Text priceText;

    public int upgradeCount;

    private bool active;

    private void Start()
    {
        active = false;
    }

    void FixedUpdate()
    {
        if (active == true)
        {
            if (Time.fixedTime > startTime + boostDuration)
            {
                PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
                move.slowdownBoost();

                SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
                spawner.updateSpawn(true);
                ThrowScript throwScript = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
                throwScript.enabled = true;
                active = false;
            }
        }
    }

    public void Activate()
    {
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateSpawn(false);

        startTime = Time.fixedTime;
        PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
        move.Boost(boostMaxspeed, boostAcceleration);

        ThrowScript throwScript = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
        throwScript.enabled = false;

        active = true;
    }

    public void buyUpgrade()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        int cost = shop.getBoostUpgradeCost(upgradeCount);
        if (player.money > cost)
        {
            boostMaxspeed += 1;
            boostDuration += 0.5f;
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
        boostMaxspeed += 1;
        boostDuration += 0.5f;
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
