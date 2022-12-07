using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System;

public class AdsManager : MonoBehaviour, IInterstitialAdListener, IRewardedVideoAdListener
{
    private const string APP_KEY = "349de07e3ef04b5f5ad846b590dd5e686011128cea4de9e1";
    private bool isOnline;

    public bool isBonus;
    public bool isGame;

    public void Initialize(bool consentVahue, bool isTesting)
    {
        isBonus = false;
        isGame = false;

        Appodeal.setTesting(isTesting);
        Appodeal.muteVideosIfCallsMuted(true);
        Appodeal.disableLocationPermissionCheck();
        Appodeal.disableWriteExternalStoragePermissionCheck();
        consentVahue = GameObject.FindWithTag("GameManager").GetComponent<Player>().consentValue;
        Appodeal.initialize(APP_KEY, adTypes: Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO, consentVahue);
    }

    #region Interstittial
    public IEnumerator IEShowInterstitial()
    {
        yield return new WaitUntil(() => Appodeal.canShow(Appodeal.INTERSTITIAL));
        Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void ShowInterstitial()
    {
        if (Appodeal.canShow(Appodeal.INTERSTITIAL))
        {
            GameObject.FindWithTag("GameManager").GetComponent<Player>().totalads++;
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
    }

    public void onInterstitialLoaded(bool isPrecache)
    {
        throw new NotImplementedException();
    }

    public void onInterstitialFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialShown()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialClosed()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialClicked()
    {
        throw new NotImplementedException();
    }

    public void onInterstitialExpired()
    {
        throw new NotImplementedException();
    }
#endregion

    public void onRewardedVideoLoaded(bool precache)
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoFailedToLoad()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoShown()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoFinished(double amount, string name)
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoClosed(bool finished)
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoExpired()
    {
        throw new NotImplementedException();
    }

    public void onRewardedVideoClicked()
    {
        throw new NotImplementedException();
    }

    public void showRewarded()
    {
        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            GameObject.FindWithTag("GameManager").GetComponent<Player>().totalads++;
            Appodeal.show(Appodeal.REWARDED_VIDEO);

            if (isBonus)
            {
                GameObject.FindWithTag("inetface").GetComponent<DailyBonus>().GetBonus();
                isBonus = false;
                isGame = false;
            }
            else if (isGame)
            {
                GameObject.FindWithTag("GameManager").GetComponent<Continuead>().WatchAdcont();
                isBonus = false;
                isGame = false;
            }
        }
        else
        {
            StartCoroutine(IEWaitForRewarded());
        }
    }

    public IEnumerator IEWaitForRewarded()
    {
        Debug.Log("Coroutine started...");
        yield return new WaitForSeconds(5f);

        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
        {
            GameObject.FindWithTag("GameManager").GetComponent<Player>().totalads++;
            Appodeal.show(Appodeal.REWARDED_VIDEO);

            if (isBonus)
            {
                GameObject.FindWithTag("inetface").GetComponent<DailyBonus>().GetBonus();
                isBonus = false;
                isGame = false;
            }
            else if (isGame)
            {
                GameObject.FindWithTag("GameManager").GetComponent<Continuead>().WatchAdcont();
                isBonus = false;
                isGame = false;
            }
        }
        else
        {
            GameObject.FindWithTag("GameManager").GetComponent<Player>().errorPanel.SetActive(true);
            if (isGame)
            {
                GameObject.FindWithTag("GameManager").GetComponent<Continuead>().SkipRev();
            }
            else if (isBonus)
            {
                DailyBonus bonus = GameObject.FindWithTag("inetface").GetComponent<DailyBonus>();
                bonus.ButtonEnabled.SetActive(true);
            }
            isBonus = false;
            isGame = false;
        }
    }

    public void showad()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }
}
