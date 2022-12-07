using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DailyBonus : MonoBehaviour
{
    public GameObject ButtonEnabled;
    public GameObject ButtonDisabled;
    public Text buttonText;
    private Player pl;
    private int bonus;
    public GameObject TextBonus;
    private int i;
    private Color colr;
    private float achannel;
    public DateTime clicktime;
    public DateTime deltat;
    public DateTime BonusDT;

    public DateTime nextBonusTime;

    public bool flag;
    public bool cycleFlag;

    private TimeSpan deltatime;

    private Vector3 startpos;

    public void watchADBonus()
    {
        AdsManager ads = GameObject.FindWithTag("GameManager").GetComponent<AdsManager>();
        ads.isBonus = true;
        ads.showRewarded();
        ButtonEnabled.SetActive(false);
    }

    public void GetBonus()
    {
        flag = false;
        ButtonEnabled.SetActive(false);
        pl = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        bonus = UnityEngine.Random.Range(1000, 5000);
        pl.updateMoney(bonus);
        
        Debug.Log("Зачислено " + bonus);
        ButtonDisabled.SetActive(true);
        TextBonus.SetActive(true);
        Text txt = TextBonus.GetComponent<Text>();
        txt.text = ("+" + bonus);
        StartCoroutine(fly());
        colr = txt.color;

        BonusDT = DateTime.Now.AddHours(6);
        Debug.Log(BonusDT);

        pl.DTP = BonusDT;
        nextBonusTime = BonusDT;

        pl.SavePlayer();

        startpos = TextBonus.transform.localPosition;


        IEnumerator fly()
        {
            achannel = colr.a;
            Text texxt = TextBonus.GetComponent<Text>();
            achannel = 1f;

            do
            {
                i++;
                achannel = achannel - 0.02f;
                TextBonus.transform.localPosition = new Vector3(TextBonus.transform.localPosition.x, TextBonus.transform.localPosition.y + i/2, TextBonus.transform.localPosition.z);
                texxt.color = new Color(texxt.color.r, texxt.color.g, texxt.color.b, achannel);
                
                yield return null;
            }
            while (achannel>0.1);

            TextBonus.transform.localPosition = startpos;
            texxt.color = new Color(texxt.color.r, texxt.color.g, texxt.color.b, 1);
            i = 0;
            TextBonus.SetActive(false);
            


        }
        
    }

    void FixedUpdate()
    {
        if (cycleFlag)
        {
            if (DateTime.Now > nextBonusTime && flag == false)
            {
                ButtonEnabled.SetActive(true);
                ButtonDisabled.SetActive(false);
                flag = true;
            }
            else
            {
                deltatime = nextBonusTime - DateTime.Now;
                buttonText.text = (deltatime.Hours + ":" + deltatime.Minutes + ":" + deltatime.Seconds);
            }
        }
    }

    public void loadTime(DateTime savedTime)
    {
        nextBonusTime = savedTime;
        if (nextBonusTime <= DateTime.Now)
        {
            ButtonEnabled.SetActive(true);
            
        }

        else
        {
            ButtonEnabled.SetActive(false);
            ButtonDisabled.SetActive(true);
            pl = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            Debug.Log("В сейве " + pl.DTP);
        }
    }
}
