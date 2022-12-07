using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{

    public GameObject EndPanel;
    public GameObject Vannn;
    private float achannel;
    private Color colr;

    public GameObject CrashText;
    public GameObject MoneyText;
    public GameObject ScoreText;
    public GameObject ButtonAgain;

    public GameObject MainInterfacee;

    public int curscore;
    public int curmoney;

    private int counermtmoney;
    private int counermtscore;

    private int moneybefore;
    private int moneyafter;

    private int scorebefore;

    public Text SessionMoney;
    public Text SessionScore;

    private Player playerScr;

    

    void Start()
    {
        EndPanel.SetActive(false);
        colr = EndPanel.GetComponent<Image>().color;
        CrashText.SetActive(false);
        MoneyText.SetActive(false);
        ScoreText.SetActive(false);
        ButtonAgain.SetActive(false);
        playerScr = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        moneybefore = playerScr.money;
    }

    public void CrashBash()
    {
        EndPanel.SetActive(true);
        EndPanel.GetComponent<Image>().color = new Color(colr.r, colr.g, colr.b, 0);
        moneyafter = playerScr.money;
        curmoney = moneyafter - moneybefore;

        StartCoroutine(Fade());

        playerScr = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        playerScr.End();

        ThrowScript throwScript = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
        throwScript.enabled = false;

    }

    

    IEnumerator Fade()
    {
        scorebefore = playerScr.score;
        curscore = scorebefore;
        achannel = 0;
        do
        {
            achannel = achannel + 0.05f;
            EndPanel.GetComponent<Image>().color = new Color(colr.r, colr.g, colr.b, achannel);
            yield return null;
        } while (EndPanel.GetComponent<Image>().color.a < 0.9f);
        MainInterfacee.SetActive(false);
        CrashText.SetActive(true);
        MoneyText.SetActive(true);
        ScoreText.SetActive(true);
        ButtonAgain.SetActive(true);
        StartCoroutine(ScoreBlin());
        
    }

    IEnumerator ScoreBlin()
    {
        do
        {
            counermtscore += 9;
            SessionScore.text = ("" + counermtscore);
            yield return new WaitForSeconds(0.00001f);

        } while (counermtscore < curscore);

        if (counermtscore > curscore)
        {
            SessionScore.text = ("" + curscore);
        }

        StartCoroutine(MoneyBlin());
    }

    IEnumerator MoneyBlin()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        if (counermtmoney < curmoney)
        {
            do
            {
                counermtmoney += 9 * player.chosenPrefabs;
                SessionMoney.text = ("" + counermtmoney);
                yield return new WaitForSeconds(0.005f);
            } while (counermtmoney < curmoney);

            if (counermtmoney > curmoney)
            {
                SessionMoney.text = ("" + curmoney);
            }
        }
        else
        {
            SessionMoney.text = ("" + 0);
        }
       
        Debug.Log("Screen loaded successfully...");
    }



}
