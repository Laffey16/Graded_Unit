using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthManager : MonoBehaviour
{
    //References the Scoremanager Component
    public static ScoreManager instance;
    //References the Text module
    public TextMeshProUGUI text;
    //Serializedfield allows it to be edited from the editor
    [SerializeField]
    //A variable made to access the player 
    private PlayerCharacter playerObj;
  
    private void FixedUpdate()
    {
        //Checks near constantly if the player health has changed
        ChangeHealth();
    }
   
    
   
    public void ChangeHealth ()
    {
        //Outputs the players health to hud as a string
        text.text = "Health: " + playerObj.Health.ToString();
    }
}
