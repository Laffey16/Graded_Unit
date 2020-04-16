using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string respawn;
    //private sub made specificially for collisions between different tags in a 2d space
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If this object collides with the tag "Player" then the if statement executes
        if (other.CompareTag("Player"))
        {
            //Using Scene Manager the player will be transported to the next scene specified by the value of the variable next level edited in the editor (probably can be automated)
            SceneManager.LoadScene(respawn);
        }
    }
}
