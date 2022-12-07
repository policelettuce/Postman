using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetID : MonoBehaviour
{
    public int seID1;
    public Vector3 PrevPosition;
    public GameObject Scroll;

    private void OnTriggerEnter(Collider coll)
    {
        string name = coll.transform.name;
        seID1 = int.Parse(name);
        Debug.Log("Секс с женщиной - это, конечно, круто, но пробовали ли вы секс с этим " + name + "?");

        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();
        shop.defineShop(seID1);
        ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
        culling.Culling(seID1);

        PrevPosition = Scroll.transform.position;
    }

    public void updateShop()
    {
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();
        shop.defineShop(seID1);
        ShopCulling culling = GameObject.FindWithTag("GameManager").GetComponent<ShopCulling>();
        culling.Culling(seID1);
    }
}
