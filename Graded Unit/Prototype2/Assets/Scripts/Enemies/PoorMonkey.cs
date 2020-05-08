using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorMonkey : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Insta kills the monkey on collisin because we ran out of time
        if (gameObject.CompareTag("Bullet"))
        {
            print("Noooooo");
            print("You know the player cant see this right");
            Destroy(gameObject);
        }            
        
    }
}
