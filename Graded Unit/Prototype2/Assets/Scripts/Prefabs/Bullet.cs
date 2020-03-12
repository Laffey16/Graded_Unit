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
        yield return new WaitForSeconds(3f);
        //Sets the gravity to one to represent bullet drop off
        RB2.gravityScale = 1;
    }

    //function to check if the bullet collides with anything
    private void OnTriggerEnter2D(Collider2D bulletcollision)
    {
        //If the bullet collides with anything that has the tag "Ground" such as the tilemap then the if statement is triggered
        if (bulletcollision.gameObject.CompareTag ("Ground"))
            //Destroys the bullet
            Destroy(gameObject);
    }
}
