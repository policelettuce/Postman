using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    private int c;

    private int throwCount;
    private int markerCount;
    private int peopleCount;

    public GameObject shopButton;
    public GameObject boostButton;
    public Text tutorialmsg;
    public Text tutorialmsglower;
    public GameObject continueButton;

    public GameObject Health;
    public GameObject Score;

    public bool forcePeopleSpawn;
    public bool forceBoostSpawn;

    public void tutorialMode()
    {
        shopButton.SetActive(false);
        boostButton.SetActive(false);
        tutorialmsg.gameObject.SetActive(false);

        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateSpawn(false);
        spawner.peopleSpawn = false;
        spawner.boostSpawn = false;
    }

    public void tutorialStart()
    {
        Health.SetActive(false);
        Score.SetActive(false);
        StartCoroutine(StartTutorial());

        StartCoroutine(ContinueButton());
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(1f);

        tutorialmsg.gameObject.SetActive(true);
        tutorialmsg.text = ("Welcome to Postman! In this game you need to deliver as many packages as you can. ");
    }

    public void continueCount()
    {
        continueButton.SetActive(false);
             if (c == 0) { SwipeMessage(); }
        else if (c == 1) { markerTutorial(); }
        else if (c == 2) { healthMessage(); }
        else if (c == 3) { scoreMessage(); }
        else if (c == 4) { peopleMessage(); }
        else if (c == 5) { peopleTutorial(); }
        else if (c == 6) { boostMessage(); }
        else if (c == 7) { boostTutorial(); }
        else if (c == 8) { boostHit(); }
        else if (c == 9)
        {
            finishMessage();
            Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            player.isTutoralCompleted = true;
            player.onGameStart();
            PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
            move.oldSpeed = 3;
        }
        else if (c == 10) { tutorialmsglower.gameObject.SetActive(false); }

        c++;
    }

    public void SwipeMessage()
    {
        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("Swipe left or right to throw the package. ");
        ThrowScript control = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
        control.isThrowActive = true;
    }

    public void ThrowCount()
    {
        throwCount++;
        if (throwCount == 5)
        {
            markerMessage();
        }
    }

    public void markerMessage()
    {
        tutorialmsg.text = ("Nice! Unfortunatelly, not everyone wants your stuff, so you need to be precise with throwing.");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(ContinueButton());
    }

    public void markerTutorial()
    {
        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("Try to hit green markers by throwing packages into them! ");

        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.spawn = true;
    }

    public void MarkerCount()
    {
        markerCount++;
        if (markerCount == 5)
        {
            moneyMessage();
        }
    }

    public void moneyMessage()
    {
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateSpawn(false);

        tutorialmsg.text = ("Well done! As you may also noticed, you get money from every marker hit. You can buy more stuff in the shop to get more money for every hit!");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(ContinueButton());
    }

    public void healthMessage()
    {
        Health.SetActive(true);
        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("This is your health. Every time you miss the throw or drive past a marker you lose one health point. When HP reaches 0 - you lose! ");

        StartCoroutine(Pause());
    }
    public void scoreMessage()
    {
        Score.SetActive(true);
        tutorialmsg.text = ("This is your score. The further you travel - the more points you get!");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(Pause());
    }

    public void peopleMessage()
    {
        tutorialmsg.text = ("Sometimes you can also find people straight on the road. You can avoid a crash with your horn, but if you hit one - you lose instantly!");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(ContinueButton());
    }

    public void peopleTutorial()
    {
        forcePeopleSpawn = true;

        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("Tap on the screen to honk and scare away a pedestrian! ");
        ThrowScript control = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
        control.isSignalActive = true;
    }

    public void PeopleCount()
    {
        peopleCount++;
        if (peopleCount == 2)
        {
            peopleFinish();
        }
    }

    public void peopleFinish()
    {
        forcePeopleSpawn = false;
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updatePeopleSpawn(false);
        tutorialmsg.text = ("Great job! Remember: one crash and you lose!");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(Pause());
    }

    public void boostMessage()
    {
        tutorialmsg.text = ("Sometimes you can find power-ups - markers with different colour. They give you temporary boost! ");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(ContinueButton());
    }

    public void boostTutorial()
    {
        forceBoostSpawn = true;
        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("Try to hit power-up with a package! ");
    }

    public void boostHit()
    {
        forceBoostSpawn = false;
        tutorialmsg.text = ("This green power-up gives you short speed-boost to gain more score. There are more different power-ups - discover them by yourself! ");
        tutorialmsg.gameObject.SetActive(true);
        tutorialmsglower.gameObject.SetActive(false);

        StartCoroutine(Pause());
    }

    public void finishMessage()
    {
        tutorialmsg.gameObject.SetActive(false);
        tutorialmsglower.gameObject.SetActive(true);
        tutorialmsglower.text = ("Well done! Let's get to work now! ");

        StartCoroutine(Pause());
    }

    IEnumerator ContinueButton()
    {
        yield return new WaitForSeconds(3f);

        continueButton.SetActive(true);
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(5f);

        continueCount();
    }

}
