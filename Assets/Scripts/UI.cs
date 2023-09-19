using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject endScreen;
    [SerializeField]
    Button nextLvlButton;
    [SerializeField]
    TextMeshProUGUI lvl;

    //Level number at the top of the screen
    public void DrawGameScreen()
    {
        lvl.text = SceneManager.GetActiveScene().name;
    }

    //Restart or next level end menu
    public void DrawEndScreen(bool isWin)
    {
        if (isWin)
        {   
            nextLvlButton.name = "Lvl" + (int.Parse(SceneManager.GetActiveScene().name[3]+"")+1);
            if (SceneManager.GetActiveScene().name == "Lvl4")
                nextLvlButton.name = "Lvl1";
            nextLvlButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
        }
        else
        {
            nextLvlButton.name = SceneManager.GetActiveScene().name;
            nextLvlButton.GetComponentInChildren<TextMeshProUGUI>().text = "Restart";
        }
        endScreen.SetActive(true);
    }
}
