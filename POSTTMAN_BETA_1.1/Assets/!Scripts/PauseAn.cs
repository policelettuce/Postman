using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAn : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    
    public GameObject PaButton;
    public GameObject StartAf;
    public GameObject PauseText;
    private int gopause;

    public void Start() {
        P1.SetActive(false);
        P2.SetActive(false);
        PauseText.SetActive(false);
        P2.GetComponent<Animator>().SetFloat("ff", 0);
        P1.GetComponent<Animator>().SetFloat("fff", 0);
        StartAf.SetActive(false);
    }
    public void PauseS() {
        P1.SetActive(true);
        P2.SetActive(true);
        PauseText.SetActive(true);
        P2.GetComponent<Animator>().SetFloat("ff", 1);
        P1.GetComponent<Animator>().SetFloat("fff", 1);
        PaButton.SetActive(false);
        StartAf.SetActive(true);    
        gopause = 1;
        
        
    }

    public void StartAfter()
    {
        PauseText.SetActive(false);
        P2.GetComponent<Animator>().SetFloat("ff",-1);
        P1.GetComponent<Animator>().SetFloat("fff", -1);
        P1.SetActive(false);
        P2.SetActive(false);
        PaButton.SetActive(true);
        StartAf.SetActive(false);
        gopause = 2;
        

    }
    public void Update() {
        if (gopause == 1)
        {
            if (Time.timeScale > 0.4f)
            {
                 
                Time.timeScale -= 0.03f;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        else if(gopause == 2)
        {
            if (Time.timeScale < 0.8f)
            {

                Time.timeScale += 0.05f;
            }
            else
            {
                Time.timeScale = 1;
            }

        }
        

    }
    




}
