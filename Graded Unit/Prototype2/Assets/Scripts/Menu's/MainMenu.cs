using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private AudioSource ClickSound;
    public void StartGame()
    {
        ClickSound = GetComponent<AudioSource>();
        //Using the Unity import "Scenemanager" by pressing the button the game loads the first level
        SceneManager.LoadScene("Scene_1");
        ClickSound.Play();
    }
    public void Controls()
    {
   
        SceneManager.LoadScene("Controls");
        ClickSound.Play();
    }

    public void QuitGame()
    {
        ClickSound.Play();
        //By pressing the button the game is closed
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
        ClickSound.Play();
    }
}

