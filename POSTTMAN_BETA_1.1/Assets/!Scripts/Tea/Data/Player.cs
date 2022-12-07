using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    #region Variables
    public int health;
    public int maxHealth;
    public Text healthText;

    public Button acButton;

    public int money;
    public Text allmoneyText;

    public int score;
    public int highscore;
    public Text scoreText;
    public Text highscoreText;
    public int scoreMultiplier;

    public int moneyMultiplier;
    public GameObject Mark;

    public bool isInMadness;

    private GameState gameState;

    private bool isGameStarted;
   

    private StuffManager stuffManager;
    public int[] isChosen;
    public int[] isBoughtCars;
    public int[] isBoughtProps;
    public int chosenPrefabs;

    private CarManager carManager;
    public int carID;

    public Bassdrop bassdrop;
    public Boost boost;
    public Doublemoney doublemoney;
    public Madness madness;
    public MaxHealth maxhealth;

    public int upgradeBassdrop;
    public int upgradeBoost;
    public int upgradeDoublemoney;
    public int upgradeMadness;
    public int upgradeMaxHealth;

    public bool[] achievement;
    public bool[] achievementGet;

    private ShopManager shop;

    private Transform vanPos;
    private float startPos;

    private Continuead ends;

    private Tutorial tutorialScript;
    public bool isTutoralCompleted;

    private Achievements achievements;

    public DailyBonus dailyBonus;
    public DateTime DTP;

    public bool consentValue;
    public bool isConsentShown;

    public GameObject consentInterface;

    public GameObject errorPanel;

    public AdsManager ads;
    public GameObject Interface;
    public GameObject moneyInterface;
    #endregion

    #region var_stats
    //highscore = highscore
    //current money = money
    public int totalgames;
    public int totalscore;
    public int totalmoney;
    public int totalstuff;
    public int totalmarkers;
    public int totalboosts;
    public int totalevades;
    public int totalcrashes;
    public int totalads;
    #endregion

    private void Start()
    {
        LoadPlayer();
        allmoneyText.text = (""+money);
        highscoreText.text = ("" + highscore);

        Debug.Log("saved time is " + DTP);

        stuffManager = GameObject.FindWithTag("Van").GetComponent<StuffManager>();
        stuffManager.loadArray(isChosen, isBoughtProps);

        carManager = GameObject.FindWithTag("Van").GetComponent<CarManager>();
        carManager.loadCar(carID, isBoughtCars);

        bassdrop = GameObject.FindWithTag("GameManager").GetComponent<Bassdrop>();
        bassdrop.loadUpgrade(upgradeBassdrop);

        boost = GameObject.FindWithTag("GameManager").GetComponent<Boost>();
        boost.loadUpgrade(upgradeBoost);

        doublemoney = GameObject.FindWithTag("GameManager").GetComponent<Doublemoney>();
        doublemoney.loadUpgrade(upgradeDoublemoney);

        madness = GameObject.FindWithTag("GameManager").GetComponent<Madness>();
        madness.loadUpgrade(upgradeMadness);

        maxhealth = GameObject.FindWithTag("GameManager").GetComponent<MaxHealth>();
        maxhealth.loadUpgrade(upgradeMaxHealth);

        shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();
        shop.loadArray(isBoughtCars, isBoughtProps);

        achievements = GameObject.FindWithTag("GameManager").GetComponent<Achievements>();
        achievements.LoadAchievements();

        errorPanel.SetActive(false);

        GameObject.FindWithTag("inetface").GetComponent<ShopEnterExit>().isADShown = false;

        ends = GameObject.FindWithTag("GameManager").GetComponent<Continuead>();

        tutorialScript = GameObject.FindWithTag("GameManager").GetComponent<Tutorial>();

        dailyBonus = GameObject.FindWithTag("inetface").GetComponent<DailyBonus>();
        dailyBonus.loadTime(DTP);
        dailyBonus.cycleFlag = true;

        ads = GameObject.FindWithTag("GameManager").GetComponent<AdsManager>();

        isInMadness = false;

        if (isTutoralCompleted == false)
        {
            tutorialScript.tutorialMode();
        }

        if (isConsentShown == false)
        {
            consentInterface.SetActive(true);
            Interface.SetActive(false);
            moneyInterface.SetActive(false);
            
        }
        else if (isConsentShown == true)
        {
            Destroy(consentInterface);
            ads.Initialize(consentValue, false);
        }
    }

    public void onGameStart()
    {
        gameState = GameObject.FindWithTag("GameManager").GetComponent<GameState>();
        isGameStarted = true;

        health = maxHealth + maxhealth.hpboost;
        healthText.text = ("" + health);

        vanPos = GameObject.FindWithTag("Van").GetComponent<Transform>();
        startPos = vanPos.position.z * scoreMultiplier;

        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        ThrowScript control = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();

        dailyBonus.cycleFlag = false;

        moneyMultiplier = 1;
        chosenPrefabs = stuffManager.count();

        if (isTutoralCompleted == false)
        {
            tutorialScript.tutorialStart();
        }
        else
        {
            spawner.updateSpawn(true);
            spawner.updatePeopleSpawn(true);
            spawner.boostSpawn = true;
            control.isSignalActive = true;
            control.isThrowActive = true;
        }
    }

    private void FixedUpdate()
    {
        if (isGameStarted == true)
        {
            score = (Mathf.RoundToInt(vanPos.position.z * scoreMultiplier - startPos))/2;
            scoreText.text = ("" + score);
            
            healthText.text = ("" + health);
        }
    }

    public void updateMoney(int value)
    {
        money += value;
        allmoneyText.text = ("" + money);
    }

    public void markerHit()
    {
        updateMoney(chosenPrefabs * 10 * moneyMultiplier);
    }

    public void markerMiss()
    {
        if (isInMadness == false && isTutoralCompleted == true)
        {
            health--;
            if (health == 0)
            {
                gameState.GameOver();
            }
        }
    }

    public void onGameEnd()
    {
        if (isTutoralCompleted == true)
        {
            healthText.text = ("" + health);

            ends.fillprogress();
            
        }
    }

    public void End()
    {
        if (score > highscore)
        {
            highscore = score;
        }
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateSpawn(false);
        spawner.updatePeopleSpawn(false);

        totalgames++;
        totalscore += score;
        EndScript endScript = GameObject.FindWithTag("GameManager").GetComponent<EndScript>();
        totalmoney += endScript.curmoney;

        Debug.Log("OnGameEnd works, cur money is " + money);

        SavePlayer();
    }

    public void UpdatePlayer()
    {
        allmoneyText.text = ("" + money);

        isChosen = stuffManager.isChosen;
        carID = carManager.carID;
        upgradeBassdrop = bassdrop.upgradeCount;
        upgradeBoost = boost.upgradeCount;
        upgradeDoublemoney = doublemoney.upgradeCount;
        upgradeMadness = madness.upgradeCount;
        upgradeMaxHealth = maxhealth.upgradeCount;
        isBoughtCars = carManager.isBought;
        isBoughtProps = stuffManager.isBought;
        SavePlayer();
    }

    public void SavePlayer()
    {
        checkAchievements();
        SaveSystem.SavePlayer(this);
        Debug.Log("Player data saved!");
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        maxHealth = data.maxHealth;
        money = data.money;
        highscore = data.highscore;
        isChosen = data.isChosen;
        carID = data.carID;
        upgradeBassdrop = data.upgradeBassdrop;
        upgradeBoost = data.upgradeBoost;
        upgradeDoublemoney = data.upgradeDoublemoney;
        upgradeMadness = data.upgradeMadness;
        upgradeMaxHealth = data.upgradeMaxHealth;
        isBoughtCars = data.isBoughtCars;
        isBoughtProps = data.isBoughtProps;
        isTutoralCompleted = data.isTutoralCompleted;
        DTP = data.DT;
        consentValue = data.consentValue;
        isConsentShown = data.isConsentShown;

        totalgames = data.totalgames;
        Debug.Log("totalgames: " + totalgames);
        totalscore = data.totalscore;
        Debug.Log("totalscore: " + totalscore);
        totalmoney = data.totalmoney;
        Debug.Log("totalmoney: " + totalmoney);
        totalstuff = data.totalstuff;
        Debug.Log("totalstuff: " + totalstuff);
        totalmarkers = data.totalmarkers;
        Debug.Log("totalmarkers: " + totalmarkers);
        totalboosts = data.totalboosts;
        Debug.Log("totalboosts: " + totalboosts);
        totalevades = data.totalevades;
        Debug.Log("totalevades: " + totalevades);
        totalcrashes = data.totalcrashes;
        Debug.Log("totalcrashes: " + totalcrashes);
        totalads = data.totalads;
        Debug.Log("totalads: " + totalads);
        Debug.Log("Player data loaded!");

        achievement = data.achievement;
        achievementGet = data.achievementGet;
    }

    public void checkAchievements()
    {
        Achievements ac = GameObject.FindWithTag("GameManager").GetComponent<Achievements>();
        if (highscore > 49999) {
            achievement[0] = true;
            ac.CompleteAchievement(0);
        }
        if (score == 1337) {
            achievement[1] = true;
            ac.CompleteAchievement(1);
        }
        int curmoney = GameObject.FindWithTag("GameManager").GetComponent<EndScript>().curmoney;
        if (curmoney > 15000) {
            achievement[2] = true;
            ac.CompleteAchievement(2);
        }
        if (curmoney == 3330) {
            achievement[3] = true;
            ac.CompleteAchievement(3);
        }
        if (money > 999999) {
            achievement[4] = true;
            ac.CompleteAchievement(4);
        }
        if (totalgames > 999) {
            achievement[5] = true;
            ac.CompleteAchievement(5);
        }
        if (isBoughtCars[4] == 1) {
            achievement[6] = true;
            ac.CompleteAchievement(6);
        }

        bool flagcars = true;
        bool flagprops = true; 
        for (int i = 0; i < isBoughtCars.Length; i++)
        {
            if (isBoughtCars[i] == 0) {
                flagcars = false;
            }
        }
        for (int i = 0; i < isBoughtProps.Length; i++)
        {
            if (isBoughtProps[i] == 0) {
                flagprops = false;
            }
        }
        if (flagcars == true && flagprops == true) {
            achievement[7] = true;
            ac.CompleteAchievement(7);
        }

        if (upgradeBassdrop == 6 && upgradeBoost == 6 && upgradeDoublemoney == 6 && upgradeMadness == 6) {
            achievement[8] = true;
            ac.CompleteAchievement(8);
        }
        if (upgradeMaxHealth == 5) {
            achievement[9] = true;
            ac.CompleteAchievement(9);
        }
        if (totalads > 100)
        {
            achievement[10] = true;
            ac.CompleteAchievement(10);
        }
    }

    public void HitSound()
    {
        AudioSource audiomark = Mark.GetComponent<AudioSource>();
        audiomark.Play();
    }

    public void consentAgree()
    {
        consentValue = true;
        isConsentShown = true;
        ads.Initialize(consentValue, false);
        SavePlayer();
        Destroy(consentInterface);
        Interface.SetActive(true);
        moneyInterface.SetActive(true);
    }

    public void consentDecline()
    {
        consentValue = false;
        isConsentShown = true;
        ads.Initialize(consentValue, false);
        SavePlayer();
        Destroy(consentInterface);
        Interface.SetActive(true);
        moneyInterface.SetActive(true);
    }
}
