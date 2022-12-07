using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPush : MonoBehaviour
{
    private Rigidbody rb;
    private int randForce;
    private int randTorque1;
    private int randTorque2;
    private int randTorque3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;

        randForce = Random.Range(-75, 75);
        randTorque1 = Random.Range(-150, 150);
        randTorque2 = Random.Range(-150, 150);
        randTorque3 = Random.Range(-150, 150);
        rb.AddForce(randForce, 10, 110);
        rb.AddTorque(randTorque1, randTorque2, randTorque3);
    }

}
