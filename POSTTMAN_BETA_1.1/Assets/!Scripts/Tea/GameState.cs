using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private PlayerMove playerMove;
    private ThrowScript throwScript;
    private Player playerReference;

    

    public bool GODMODE;

    public void GameOver()
    {
        if (GODMODE == false)
        {
            throwScript = GameObject.FindWithTag("Van").GetComponent<ThrowScript>();
            throwScript.enabled = false;
            playerReference = GameObject.FindWithTag("GameManager").GetComponent<Player>();
            playerReference.onGameEnd();
            
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
