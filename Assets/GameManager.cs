using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameStates gameState;
    UI uI;

    private void Awake()
    {
        uI = GameObject.Find("Canvas").GetComponent<UI>();
        ChangeGameState(GameStates.Playing);
    }

    public void ChangeGameState(GameStates newState)
    {
        switch (newState)
        {
            case GameStates.Playing:
                uI.DrawGameScreen();
                break;
            case GameStates.Over:
                uI.DrawEndScreen(false);
                break;
            case GameStates.Win:
                uI.DrawEndScreen(true);
                break;
            case GameStates.Menu:
                break;
        }
        gameState = newState;
    }

    public enum GameStates
    {
        Playing,
        Over,
        Win,
        Menu
    }
}
