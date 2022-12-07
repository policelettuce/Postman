using UnityEngine;
using System.Collections;

public class ThrowScript : MonoBehaviour
{

    public Transform spawnPos;

    public bool isSignalActive;
    private bool flag;
    private bool isDraging;
    private Vector2 startTouch, swipeDelta;

    public float signalCooldown;
    public float cooldown;
    private float nextSpawnTimeL;
    private float nextSpawnTimeR;

    public Collider signalRange;
    private float signalTime;

    public bool isThrowActive;

    private void Update()
    {
        swipeDelta = Vector2.zero;

        #region PC input
        if (Input.GetMouseButtonDown(0))
        {
            flag = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile input
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                flag = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        if (isDraging && isThrowActive)
        {
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        if (swipeDelta.magnitude > 75)
        {
            if (swipeDelta.x > 0 && Time.time > nextSpawnTimeR)
            {
                nextSpawnTimeR = Time.time + cooldown;

                StuffManager manager = gameObject.GetComponent<StuffManager>();
                manager.throwStuff(1, spawnPos);
                Reset();
                flag = false;
            }
            else if (swipeDelta.x < 0 && Time.time > nextSpawnTimeL)
            {
                nextSpawnTimeL = Time.time + cooldown;

                StuffManager manager = gameObject.GetComponent<StuffManager>();
                manager.throwStuff(0, spawnPos);
                Reset();
                flag = false;
            }
        }

        if (isDraging == false && flag == true && isSignalActive == true)
        {
            if (Time.time - signalTime > signalCooldown)
            {
                Debug.Log("beep beep motherfucka");
                flag = false;
                signalRange.enabled = true;
                signalTime = Time.time;
            }
        }

        if (Time.time - signalTime > 0.3)
        {
            signalRange.enabled = false;
        }

    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

}
