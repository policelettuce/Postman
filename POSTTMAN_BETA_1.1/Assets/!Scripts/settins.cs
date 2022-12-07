using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settins : MonoBehaviour
{
    public Slider slider;

    public GameObject SoundOFF;
    public GameObject SoundON;
    public AudioSource Myzlo;
    public Text offon;

    void Start()
    {
        SoundOFF.SetActive(true);
        SoundON.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Myzlo.volume = slider.value;
    }

    public void SoundONfunc()
    {
        slider.value = 100f;
        Myzlo.volume = slider.value;
       
        SoundOFF.SetActive(true);
        SoundON.SetActive(false);
        offon.text = ("ON");

        
    }
    public void SoundOFFfunc()
    {
        slider.value = 0f;
        SoundON.SetActive(true);
        SoundOFF.SetActive(false);
        offon.text = ("OFF");



    }

}
