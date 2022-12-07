using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseError : MonoBehaviour
{
    public GameObject panel;

    public void buttonClick()
    {
        panel.SetActive(false);
    }
}
