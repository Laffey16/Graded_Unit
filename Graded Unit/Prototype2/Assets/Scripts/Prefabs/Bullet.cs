using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //A public float used to set how fast the bullet flies
    public float speed = 15f;
    public Rigidbody2D RB2;
    // Start is called before the first frame update
    void Start()
    {

        //As soon as the bullet is spawned the bullet will travel to the right at the speed of variable "speed"
        RB2.velocity = transform.right * speed;
        //Runs the function DropOff using couritines. Couritines are used for delays in Unity
        StartCoroutine(Dropoff());
    }

    //Us
    public IEnumerator Dropoff()
    {
        //After waiting for 3 seconds this function will trigger
        yield return new WaitForSeconds(0.5f);
        //Sets the gravity to one to represent bullet drop off
        RB2.gravityScale = 2;
    }

    //function to check if the bullet collides with anything
    private void OnTriggerEnter2D(Collider2D bulletcollision)
    {
        //Since the the player can touch there own bullet this allows for the bullet to phase through them instead
        if (bulletcollision.gameObject.CompareTag("Player"))
        {

        }
        //Allows coins to be shot through
        else if (bulletcollision.gameObject.CompareTag("Coins"))
        {

        }
        //Anything else such as an enemy or the ground will destroy the bullet
        else
        {
            Destroy(gameObject);
        } 
    
   
    }
}
