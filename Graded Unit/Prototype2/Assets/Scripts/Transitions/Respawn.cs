using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    //private sub made specificially for collisions between different tags in a 2d space
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object collides with the tag "Player" then the if statement executes
        if (other.CompareTag("Player"))
        {
            //Reloads the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
