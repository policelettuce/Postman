using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffManager : MonoBehaviour
{

    public GameObject[] stuff;
    private GameObject clone;
    public int[] isChosen;
    private GameObject[] chosenStuff;

    public int[] isBought;

    private float speed;
    private float sideForce;
    private float forwardForce;

    public int object_id;
    public GameObject scrolling;
    public GameObject Snd;

    public void loadArray(int[] array, int[] boughtarray)
    {
        isChosen = array;
        isBought = boughtarray;
    }

    public int count()
    {
        int c = 0;
        for (int i = 0; i < isChosen.Length; i++)
        {
            if (isChosen[i] == 1)
            {
                c++;
            }
        }
        return c;
    }

    private void FixedUpdate()
    {
        PlayerMove move = GetComponent<PlayerMove>();
        speed = move.speed;
        forwardForce = 70 * (speed - 2) + 50;
        sideForce = 125 - 11 * (speed - 2);
    }

    public void selectOrBuy()
    {
        GetID id = scrolling.GetComponent<GetID>();
        object_id = id.seID1;
        if (isBought[object_id] == 1)
        {
            select();
        }
        else if (isBought[object_id] == 0)
        {
            buyProp();
        }
    }

    public void select()
    {
        if (isChosen[object_id] == 0)
        {
            isChosen[object_id] = 1;
            Debug.Log(object_id + " is chosen!");
        }
        else if (isChosen[object_id] == 1)
        {
            if (count() == 1)
            {
                Debug.Log("Can't discard, at least 1 prop must be chosen!");
            }
            else
            {
                isChosen[object_id] = 0;
                Debug.Log(object_id + " is discarded!");
            }
        }
    }

    public void buyProp()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        ShopManager shop = GameObject.FindWithTag("GameManager").GetComponent<ShopManager>();

        if (player.money > shop.getPropPrice(object_id))
        {
            player.money -= shop.getPropPrice(object_id);
            isBought[object_id] = 1;
            AudioSource audio = Snd.GetComponent<AudioSource>();
            audio.Play();
        }
        select();
    }

    public void generateArray()
    {
        int c = 0;

        if (count() == 0)
        {
            chosenStuff = new GameObject[1];
            chosenStuff[0] = stuff[0];
        }
        else
        {
            chosenStuff = new GameObject[count()];
            for (int i = 0; i < stuff.Length; i++)
            {
                if (isChosen[i] == 1)
                {
                    chosenStuff[c] = stuff[i];
                    c++;
                }
            }
            Debug.Log(count() + " - amount of chosen objects");
            for (int i = 0; i < stuff.Length; i++)
            {
                Debug.Log("id: " + i + " is chosen: " + isChosen[i]);
            }
        }
    }

    public void throwStuff(int direction, Transform spawnPos)
    {
        if (direction == 1)
        {
            int randomIndex = Random.Range(0, chosenStuff.Length);
            clone = Instantiate(chosenStuff[randomIndex], spawnPos.position, spawnPos.rotation);
            clone.GetComponent<Rigidbody>().AddForce(sideForce, 75, forwardForce);
            Destroy(clone, 3.0f);
        }

        else if (direction == 0)
        {
            int randomIndex = Random.Range(0, chosenStuff.Length);
            clone = Instantiate(chosenStuff[randomIndex], spawnPos.position, spawnPos.rotation);
            clone.GetComponent<Rigidbody>().AddForce(-sideForce, 75, forwardForce);
            Destroy(clone, 1.0f);
        }

        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        player.totalstuff++;
        if (!player.isTutoralCompleted)
        {
            Tutorial tutorial = GameObject.FindWithTag("GameManager").GetComponent<Tutorial>();
            tutorial.ThrowCount();
        }
    }
}
