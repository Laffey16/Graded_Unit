using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WILL BE EXPANEDED UPON
public class EnemyBehaviour : MonoBehaviour
{
    //If this object is intereacted with something other
    private void OnTriggerEnter2D(Collider2D other)
    {
        //And this object happens to interact with a bullet
        if (other.CompareTag("Bullet"))
        {
            //It dies
            Destroy(gameObject);
        }
    }
}
