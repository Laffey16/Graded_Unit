using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Respawn : MonoBehaviour
{
    private PlayerCharacter playerObj;
    public TextMeshProUGUI GameOverText;
    public Transform PauseButton;
    public Transform MenuButton;
    public AudioSource BackgroundMusic;
    public bool IsDead;
    private void Awake()
    {
        IsDead = false;
        //Sets the game back to regular speed for when the scene restarts
        Time.timeScale = 1;
        //References the Player so the players health can be checked
        playerObj = GameObject.FindObjectOfType<PlayerCharacter>();
        //Hides all the game over HUD
        GameOverText.gameObject.SetActive(false);
        PauseButton.gameObject.SetActive(false);
        MenuButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        //If the players health is 0
        if(playerObj.Health <=0)
        {
           
            //Runs the Gameover Method
            GameOver();
        }
       
    }

    //private sub made specificially for collisions between different tags in a 2d spac
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object collides with the tag "Player" then the if statement executes
        if (other.CompareTag("Player"))
        {
            //Gameover
            GameOver();
        }
    }
    public void GameOver()
    {
        IsDead = true;
        //Shows all game HUD needed for a game over screen
        GameOverText.gameObject.SetActive(true);
        PauseButton.gameObject.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        //Stops the background music
        BackgroundMusic.Stop();
        Time.timeScale = 0;
        print("Dead");
    }
    public void Restart()
    {
        print("Restarting");
        //The scene reloads and the player restarts the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        //Returns to the main menu if the player wanted to
        SceneManager.LoadScene("MainMenu");
    }
}

