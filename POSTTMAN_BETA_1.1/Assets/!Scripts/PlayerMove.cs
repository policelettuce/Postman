using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform cc;
    Vector3 moveVec;

    public float speed;
    public float acceleration;
    public float maxspeed;

    public float oldSpeed;
    public float oldMaxspeed;
    public float oldAcceleration;
    private bool slowing;

    public bool isGameStarted;

    void Start()
    {
        isGameStarted = false;
        slowing = false;
        cc = GetComponent<Transform>();
        moveVec = new Vector3(0, 0, 1);
    }

    
    void FixedUpdate()
    {
        if (isGameStarted == true && speed <= 3)
        {
            acceleration = 0.03f;
            speed = 3;
            isGameStarted = false;
        }

        if (slowing == true && speed <= oldSpeed)
        {
            maxspeed = oldMaxspeed;
            speed = oldSpeed;
            acceleration = oldAcceleration;
            slowing = false;
        }
        speed += Time.deltaTime * acceleration;
        if (speed > maxspeed)
        {
            speed = maxspeed;
        }
        cc.position += moveVec*Time.deltaTime*speed;
    }

    public void Boost(float boostMaxspeed, float boostAcceleration)
    {
        oldSpeed = speed;
        oldMaxspeed = maxspeed;
        oldAcceleration = acceleration;
        maxspeed = boostMaxspeed;
        acceleration = boostAcceleration;
    }

    public void slowdownBoost()
    {
        acceleration *= -2;
        slowing = true;
    }
}
