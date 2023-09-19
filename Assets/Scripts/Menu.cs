using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    //Loading the scene with the button name
    public void ButtonClick(Button btn)
    {
        SceneManager.LoadScene(btn.name);
    }
}
