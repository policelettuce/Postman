using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{

    private Rigidbody rb;
    private int randForce1;
    private int randForce2;
    private int randTorque1;
    private int randTorque2;
    private int randTorque3;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;

        randForce1 = Random.Range(-150, 150);
        randForce2 = Random.Range(-150, 150);
        randTorque1 = Random.Range(-150, 150);
        randTorque2 = Random.Range(-150, 150);
        randTorque3 = Random.Range(-150, 150);
        rb.AddForce(randForce1, 300, randForce2);
        rb.AddTorque(randTorque1, randTorque2, randTorque3);

        Destroy(gameObject, 7.0f);
    }
}
