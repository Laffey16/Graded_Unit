using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    //References the Scoremanager Component
    public static ScoreManager instance;
    //References the Text module
    public TextMeshProUGUI text;
   
    //A variable made to access the player 
    private PlayerCharacter playerObj;
    private void Awake()
    {
        //Finds the player character and sets and sets the variable playerObj to them so it can be accessed
        playerObj = GameObject.FindObjectOfType<PlayerCharacter>();
    }
    private void FixedUpdate()
    {
        ChangeScore();
    }

    // Update is called once per frame
    public void ChangeScore()
    {
        //Outputs X + whatever the score is (converting it from a integer to a string)
        text.text = "X" + playerObj.coins.ToString();
        // A little congratulations if the player gets all coiins
        if (playerObj.coins == 16)
        {
            print("Congratulations");
        }
    }
}
