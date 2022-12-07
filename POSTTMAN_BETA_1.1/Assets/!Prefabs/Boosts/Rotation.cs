using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform Hatsune_Miku;

    private void Start()
    {
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        do
        {
            Hatsune_Miku.Rotate(0, 1f, 0);
            yield return new WaitForSeconds(0.01f);
        } while (true);
    }
}
