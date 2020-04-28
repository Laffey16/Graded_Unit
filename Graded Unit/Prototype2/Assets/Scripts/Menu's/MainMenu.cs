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
        //Loads the Controls Scene to show players the games controls
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        
        //By pressing the button the game is closed
        Application.Quit();
    }

    public void Back()
    {
        //Goes back from the controls window back to the main menu
        SceneManager.LoadScene("MainMenu");
    }
}

