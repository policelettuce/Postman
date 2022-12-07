using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashText : MonoBehaviour {

    public float time = 0;
    public float hz;

    void Update () {

        time += hz;
        if (time >= 5) {
            GetComponent<Text>().enabled = true;
        }
        if (time >= 10) {
            GetComponent<Text>().enabled = false;
            time = 0;
        }
	}
}
