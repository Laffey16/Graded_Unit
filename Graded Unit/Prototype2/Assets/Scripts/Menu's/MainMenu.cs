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
        
        //Loads the story so you can then start the game
        SceneManager.LoadScene("Story");
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
    public void StoryStart()
    {
        //Loads the first level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StoryRestart()
    {
        //Reloads the story
        SceneManager.LoadScene("MainMenu");
    }
}

