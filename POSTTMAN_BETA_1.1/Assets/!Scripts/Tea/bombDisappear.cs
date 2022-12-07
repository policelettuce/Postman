using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDisappear : MonoBehaviour
{
    public GameObject mesh;

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(mesh);
    }
}
