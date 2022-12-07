using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData 
{
    public int maxHealth;
    public int money;
    public int highscore;
    public int[] isChosen;
    public int carID;
    public int upgradeBassdrop;
    public int upgradeBoost;
    public int upgradeDoublemoney;
    public int upgradeMadness;
    public int upgradeMaxHealth;
    public int[] isBoughtCars;
    public int[] isBoughtProps;
    public bool isTutoralCompleted;

    public int totalgames;
    public int totalscore;
    public int totalmoney;
    public int totalstuff;
    public int totalmarkers;
    public int totalboosts;
    public int totalevades;
    public int totalcrashes;
    public int totalads;

    public bool consentValue;
    public bool isConsentShown;

    public bool[] achievement;
    public bool[] achievementGet;

    public DateTime DT;

    public PlayerData (Player player)
    {
        maxHealth = player.maxHealth;
        money = player.money;
        highscore = player.highscore;
        isChosen = player.isChosen;
        carID = player.carID;
        upgradeBassdrop = player.upgradeBassdrop;
        upgradeBoost = player.upgradeBoost;
        upgradeDoublemoney = player.upgradeDoublemoney;
        upgradeMadness = player.upgradeMadness;
        upgradeMaxHealth = player.upgradeMaxHealth;
        isBoughtCars = player.isBoughtCars;
        isBoughtProps = player.isBoughtProps;
        isTutoralCompleted = player.isTutoralCompleted;

        totalgames = player.totalgames;
        totalscore = player.totalscore;
        totalmoney = player.totalmoney;
        totalstuff = player.totalstuff;
        totalmarkers = player.totalmarkers;
        totalboosts = player.totalboosts;
        totalevades = player.totalevades;
        totalcrashes = player.totalcrashes;
        totalads = player.totalads;

        consentValue = player.consentValue;
        isConsentShown = player.isConsentShown;

        achievement = player.achievement;
        achievementGet = player.achievementGet;

        DT = player.DTP;
    }

    public PlayerData ()
    {
        maxHealth = 5;
        money = 0;
        highscore = 0;
        isChosen = new int[10];
        isChosen[0] = 1;
        carID = 0;
        upgradeBassdrop = 0;
        upgradeBoost = 0;
        upgradeDoublemoney = 0;
        upgradeMadness = 0;
        upgradeMaxHealth = 0;
        isBoughtCars = new int[7];
        isBoughtCars[0] = 1;
        isBoughtProps = new int[10];
        isBoughtProps[0] = 1;
        isTutoralCompleted = false;

        totalgames = 0;
        totalscore = 0;
        totalmoney = 0;
        totalstuff = 0;
        totalmarkers = 0;
        totalboosts = 0;
        totalevades = 0;
        totalcrashes = 0;
        totalads = 0;

        achievement = new bool[11];
        achievementGet = new bool[11];

        consentValue = false;
        isConsentShown = false;

        DT = DateTime.Now;
    }

}
