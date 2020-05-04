using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditorInternal;

public class ScoreManager : MonoBehaviour
{
    //References the Scoremanager Component
    public static ScoreManager instance;
    //References the Text module
    public TextMeshProUGUI CoinText;
    //A variable made to access the player 
    private PlayerCharacter playerObj;
    private Respawn RespawnObj;
    public TextMeshProUGUI PausedText;
    private bool IsPaused; 
    private void Start()
    {
        IsPaused = false;
        //Finds the player character script and sets and sets the variable playerObj to them so it can be accessed
        playerObj = GameObject.FindObjectOfType<PlayerCharacter>();
        //Finds the Transition scene script and sets and sets the variable playerObj to them so it can be accessed
        RespawnObj = GameObject.FindObjectOfType<Respawn>();
    }
    
    private void Update()
    {
        Pausing();
    }
    private void Pausing()
    {
        //If the player presses play and isnt paused
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false && RespawnObj.IsDead == false)
        {
            //The pause menu will appear (borrowed from game over)
            RespawnObj.PauseButton.gameObject.SetActive(true);
            RespawnObj.MenuButton.gameObject.SetActive(true);
            //Pauses the game by setting the timescale to 0 (0% of the original game speed)
            Time.timeScale = 0;
            //States in the HUD its paused
            PausedText.text = "Currently Paused";
            //Sets a variable stating the game is paused (Used to decide if to pause or unpause)
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
        {
            //Disables the pause menu
            RespawnObj.PauseButton.gameObject.SetActive(false);
            RespawnObj.MenuButton.gameObject.SetActive(false);
            //Sets the game to the original speed
            Time.timeScale = 1;
            //States nothing in the hud
            PausedText.text = "";
            //Sets the variable saying the game isnt paused anymore
            IsPaused = false;
        }
    }
    private void FixedUpdate()
    {
        ChangeScore();
    }

    // Update is called once per frame
    public void ChangeScore()
    {
        //Outputs X + whatever the score is (converting it from a integer to a string)
        CoinText.text = "X" + playerObj.coins.ToString();
        // A little congratulations if the player gets all coiins
        if (playerObj.coins == 16)
        {
            print("Congratulations");
        }

    }
}
