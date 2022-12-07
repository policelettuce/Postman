using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continuead : MonoBehaviour
{
    public Image bar;
    public GameObject Review;
    private bool fillbool = true;
    private bool rev = true;
    private float oldspeed;

    public void fillprogress()
    {
        if (rev)
        {
            
            StartCoroutine(SlowDown());
            rev = false;
        }
        else
        {
            EndScript end = GameObject.FindWithTag("GameManager").GetComponent<EndScript>();
            StartCoroutine(SlowDownSecond());
           
        }
    }

    IEnumerator Fill()
    {
        do
        {
            if (fillbool)
            {
                bar.fillAmount -= 0.005f;
            }
            yield return null;
        } while (bar.fillAmount > 0);
        EndScript end = GameObject.FindWithTag("GameManager").GetComponent<EndScript>();
        Debug.Log("Произошёл КрашБаш...");
        end.CrashBash();
        Destroy(Review);
    }

    IEnumerator SlowDown()
    {

        PlayerMove sp = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
        oldspeed = sp.speed;

        do
        {
            sp.speed -= 0.1f;
            yield return null;
        } while (sp.speed > 0.2f);
        sp.speed = 0;
        sp.acceleration = 0;
        Review.SetActive(true);
        StartCoroutine(Fill());
    }

    public void watchAD()
    {
        fillbool = false;
        AdsManager ads = GameObject.FindWithTag("GameManager").GetComponent<AdsManager>();
        ads.isGame = true;
        ads.showRewarded();
    }

    public void WatchAdcont()
    {
        PlayerMove sp = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();

        Destroy(Review);
        sp.speed = oldspeed;
        sp.acceleration = 0.03f;
        Player plyr = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        plyr.health = 3;
        plyr.healthText.text = ("" + 3);
        ThrowScript throwScr = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
        throwScr.enabled = true;

        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.destroyAllBoosts();
        spawner.destroyAllMarkers();
        spawner.destroyPeople();
    }

    public void SkipRev()
    {
        fillbool = false;
        EndScript end = GameObject.FindWithTag("GameManager").GetComponent<EndScript>();
        end.CrashBash();
        Destroy(Review);
    }

    IEnumerator SlowDownSecond()
    {
        PlayerMove sp = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
        do
        {
            sp.speed -= 0.1f;
            yield return null;
        } while (sp.speed > 0.2f);
        sp.speed = 0;
        sp.acceleration = 0;
        EndScript end = GameObject.FindWithTag("GameManager").GetComponent<EndScript>();
        end.CrashBash();
    }
}
