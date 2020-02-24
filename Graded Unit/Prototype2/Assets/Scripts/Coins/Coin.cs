using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script applied to coins to check if they collide with the player and then change the score accordingly
public class Coin : MonoBehaviour
{
    //sets the value of the coin to 1 so they tally up 
    public int coinValue = 1;
    //Creates a variable coin sound
    public AudioSource coinSound;

    private void Start()
    {
        //Gives a sound effect to the coinSound variable using the AudioSource component
        coinSound = GetComponent<AudioSource>();
    }
    //Checks for collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Checks if the coin collides with the player
        if(other.gameObject.CompareTag("Player"))
        {
            //Changes the score on the HUD
            ScoreManager.instance.ChangeScore(coinValue);
          

        }
    }
}
