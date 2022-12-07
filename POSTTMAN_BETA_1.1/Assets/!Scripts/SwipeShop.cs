using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeShop : MonoBehaviour, IBeginDragHandler, IDragHandler
{

    public GameObject Massive;
    public GameObject PropMassive;
    private Vector3 needpos;
    private Vector3 needposprop;

    void Start()
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if ((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)))
        {
            ShopEnterExit shp = GameObject.FindWithTag("inetface").GetComponent<ShopEnterExit>();
            Debug.Log(shp.isTruckShopActive);
            if (shp.isTruckShopActive)
            {
                if (eventData.delta.x > 0)
                {
                    
                    if (Massive.transform.localPosition.z >= 0.4f)
                    {
                        needpos = Massive.transform.localPosition - new Vector3(0, 0, 6f);
                        StartCoroutine(SwipeSlowBack());
                    }

                }
                else
                {
                    
                    if (Massive.transform.localPosition.z <= 30.3f)
                    {
                        needpos = Massive.transform.localPosition + new Vector3(0, 0, 6f);
                        StartCoroutine(SwipeSlow());
                    }
                }

            }
            else
            {
                if (eventData.delta.x > 0)
                {
                    
                    if (PropMassive.transform.localPosition.z > 0.5f)
                    {
                        needposprop = PropMassive.transform.localPosition - new Vector3(0, 0, 5f);
                        StartCoroutine(SwipeSlowProp());
                    }
                }

                else
                {
                    
                    if (PropMassive.transform.localPosition.z < 45.4f)
                    {
                        needposprop = PropMassive.transform.localPosition + new Vector3(0, 0, 5f);
                        StartCoroutine(SwipeSlowBackProp());
                    }
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    IEnumerator SwipeSlow()
    {
        do
        {
            Massive.transform.localPosition += new Vector3(0, 0, 0.5f);
            yield return null;
        } while (needpos.z > Massive.transform.localPosition.z);
    }

    IEnumerator SwipeSlowBack()
    {
        do
        {
            Massive.transform.localPosition -= new Vector3(0, 0, 0.5f);
            yield return null;
        } while (needpos.z < Massive.transform.localPosition.z);
    }


    IEnumerator SwipeSlowProp()
    {
        do
        {
            PropMassive.transform.localPosition -= new Vector3(0, 0, 0.5f);
            yield return null;
        } while (needposprop.z < PropMassive.transform.localPosition.z);
    }

    IEnumerator SwipeSlowBackProp()
    {
        do
        {
            PropMassive.transform.localPosition += new Vector3(0, 0, 0.5f);
            yield return null;
        } while (needposprop.z > PropMassive.transform.localPosition.z);
    }
}