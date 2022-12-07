using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject MainVan;
    public GameObject Text1;
    public GameObject Text2;

    public GameObject HIGHSCORE;
    public GameObject HSICO;
    public GameObject CurSco;

    public GameObject Buttonleft;
    public GameObject Buttonleft2;
    public GameObject ButtonRight;
    public GameObject ButtonRight2;
    
    public GameObject MainButton;
    public GameObject PauseIc;
   

    public GameObject BassdropButton;    

    public Text chan;

    public GameObject SHPTrucks;
    public GameObject SHPPrps;

    public GameObject RoadSPWN;
    public GameObject Signal;
    public GameObject VehCol;

    public GameObject Healthsystem;

    public GameObject[] PeopleForCrash;

    private Player playerReference;

    public bool isGameStarted;

    void Start()
    {
        isGameStarted = false;
        SpawnerManager spawner = GameObject.FindWithTag("GameManager").GetComponent<SpawnerManager>();
        spawner.updateSpawn(false);
        spawner.updatePeopleSpawn(false);
        CurSco.SetActive(false);
        PauseIc.SetActive(false);
        VehCol.SetActive(false);
        Signal.SetActive(false);
        
        BassdropButton.SetActive(false);
        Healthsystem.SetActive(false);

        PlayerMove move = GameObject.FindWithTag("Van").GetComponent<PlayerMove>();
        move.speed = 7;
    }

    public void St()

    {

        PlayerMove mv = MainVan.GetComponent<PlayerMove>();
        mv.acceleration = -1f;
        mv.isGameStarted = true;
        Object.Destroy(Text2);
        HIGHSCORE.SetActive(false);
        HSICO.SetActive(false);
        CurSco.SetActive(true);
        ThrowScript th = MainVan.GetComponent<ThrowScript>();
        th.enabled = true;

        Animator an = Text1.GetComponent<Animator>();
        an.enabled = true;

        Animator an2 = Buttonleft.GetComponent<Animator>();
        an2.enabled = true;

        Animator an22 = Buttonleft2.GetComponent<Animator>();
        an22.enabled = true;

        Animator an3 = ButtonRight.GetComponent<Animator>();
        an3.enabled = true;

        Animator an4 = ButtonRight2.GetComponent<Animator>();
        an4.enabled = true;



        StartCoroutine(Del());
        VehCol.SetActive(true);
        Signal.SetActive(true);
        PauseIc.SetActive(true);
        Healthsystem.SetActive(true);

        isGameStarted = true;

        playerReference = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        playerReference.onGameStart();

        StuffManager manager = MainVan.GetComponent<StuffManager>();
        manager.generateArray();

        GameState gamestate = GameObject.FindWithTag("GameManager").GetComponent<GameState>();
        gamestate.GODMODE = false;
    }


    IEnumerator Del() {
        yield return new WaitForSeconds(2);
        Object.Destroy(Text1);
        Object.Destroy(Buttonleft);
        Object.Destroy(Buttonleft2);
        Object.Destroy(ButtonRight);
        Object.Destroy(MainButton);
        Object.Destroy(ButtonRight2);
        

    }

    
        
    }
