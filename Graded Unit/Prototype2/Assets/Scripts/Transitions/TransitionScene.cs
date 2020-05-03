using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//loads the required function scenemanager needed for transitions between scenes
using UnityEngine.SceneManagement;
public class TransitionScene : MonoBehaviour
{
    //A serialized field allows the variable to be edited from the editor without making it a public 
    //Next Level is made to assign a scene for transition between levels
    //private sub made specificially for collisions between different tags in a 2d space
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object collides with the tag "Player" then the if statement executes
        if (other.CompareTag("Player"))
        {
            //Using Scene Manager the player will be transported to the next scene specified by the value of the variable next level edited in the editor (probably can be automated)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
