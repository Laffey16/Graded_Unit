using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //References the Scoremanager Component
    public static ScoreManager instance;
    //References the Text module
    public TextMeshProUGUI text;
    //A variable made to access the player 
    private PlayerCharacter playerObj;
    //When the game is loaded
    public Slider slider;
    private void Awake()
    {
        //Finds the player character and sets and sets the variable playerObj to them so it can be accessed
        playerObj = GameObject.FindObjectOfType<PlayerCharacter>();
        HealthBar();
    }
    private void HealthBar()
    {
        //Sets the Max Health to the starting health
        slider.maxValue = playerObj.Health;
    }
    private void FixedUpdate()
    {
        //Checks near constantly if the player health has changed
        ChangeHealth();
    }
   
    public void ChangeHealth ()
    {
        //Outputs the players health to hud as a string
        text.text = "Health: " + playerObj.Health.ToString();
        slider.value = playerObj.Health;
        
    }
}
