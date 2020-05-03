using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private AudioSource MenuSounds;
    public AudioClip ClickSound;
    public AudioClip other;
    public void Start()
    {
        MenuSounds = GetComponent<AudioSource>();
    }
    public void StartGame()
    {
        
        //Using the Unity import "Scenemanager" by pressing the button the game loads the first level
        SceneManager.LoadScene("Scene_1");
        MenuSounds.clip = ClickSound;
        MenuSounds.Play();
        
    }
    public void Controls()
    { 
        //Loads the Controls Scene to show players the games controls
        SceneManager.LoadScene("Controls");
         MenuSounds.clip = ClickSound;
        MenuSounds.Play();
    }

    public void QuitGame()
    {
        
        //By pressing the button the game is closed
        Application.Quit();
        MenuSounds.clip = ClickSound;
        MenuSounds.Play();
    }

    public void Back()
    {
        //Goes back from the controls window back to the main menu
        SceneManager.LoadScene("MainMenu");
        MenuSounds.clip = ClickSound;
        MenuSounds.Play();
    }
}

