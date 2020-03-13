using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //Using the Unity import "Scenemanager" by pressing the button the game loads the first level
        SceneManager.LoadScene("Scene_1");
    }

    public void QuitGame()
    {
        //By pressing the button the game is closed
        Application.Quit();
    }
}

