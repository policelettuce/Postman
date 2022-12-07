using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public void Activate()
    {
        Player player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        player.health++;
    }
}
