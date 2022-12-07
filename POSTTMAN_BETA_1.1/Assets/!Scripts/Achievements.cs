using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    public GameObject[] AchivButtons;
    public GameObject[] AchivMain;

    public Player player;

    public void LoadAchievements()
    {
        player = GameObject.FindWithTag("GameManager").GetComponent<Player>();
        for (int i = 0; i < 10; i++)
        {
            if (player.achievement[i] == true && player.achievementGet[i] == false)
            {
                CompleteAchievement(i);
            }
            else if (player.achievement[i] == true && player.achievementGet[i] == true)
            {
                Destroy(AchivButtons[i]);
                AchivMain[i].GetComponent<Image>().color = new Color(0f / 255.0f, 255f / 255.0f, 114f / 255.0f, 100f / 255.0f);
            }
        }
    }

    public void CompleteAchievement(int achivID)
    {
        if (player.achievementGet[achivID] == false)
        {
            AchivButtons[achivID].SetActive(true);
        }
    }

    public void GetReward(int buttonachID)
    {
        Destroy(AchivButtons[buttonachID]);
        player.achievementGet[buttonachID] = true;
        player.money += 20000;
        player.SavePlayer();
        AchivMain[buttonachID].GetComponent<Image>().color = new Color(0f/255.0f,255f/255.0f,114f/255.0f,100f/255.0f);
    }
}
