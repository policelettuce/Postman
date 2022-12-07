using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maxscroll : MonoBehaviour
{
    public GameObject scrolll;
    public float coord;
    public bool IsScroll;
    public GameObject scrollvie;
    

    private float gotopos;

    void Start()
    {


    }
    void FixedUpdate()
    {
        coord = scrolll.GetComponent<RectTransform>().position.x;
        scrollvie.GetComponent<ScrollRect>().inertia = true;

        if (coord >= -7650)
        {
            scrollvie.GetComponent<ScrollRect>().inertia = false;
            scrolll.transform.localPosition -= new Vector3(2000 * Time.fixedDeltaTime, scrolll.transform.localPosition.y, scrolll.transform.localPosition.z);
        }
        else if (coord <= -15850)
        {
            scrollvie.GetComponent<ScrollRect>().inertia = false;
            scrolll.transform.localPosition += new Vector3(2000 * Time.fixedDeltaTime, scrolll.transform.localPosition.y, scrolll.transform.localPosition.z);
        }

       

        

    }
    public void IsScrollin(bool scr)
    {
        IsScroll = scr;
    }

  
}
