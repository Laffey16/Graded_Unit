using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//WILL BE EXPANEDED UPON
public class EnemyBehaviour : MonoBehaviour
{//Enemy health
    public int health=5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //And this object happens to interact with a bullet
        if (other.CompareTag("Bullet"))
        {
            //minus 1 health
            health -= 1;
        }
        //If their health is equal to 0 they die
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }
    


}
