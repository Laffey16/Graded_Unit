using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//WILL BE EXPANEDED UPON
public class EnemyBehaviour : MonoBehaviour
{//Enemy health
    public int health=5;
    public Slider slider;

    private void Start()
    {
        HealthBar();
    }
    private void HealthBar()
    {
        slider.maxValue = health;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {

        slider.value = health;
        //And this object happens to interact with a bullet
        if (other.CompareTag("Bullet"))
        {
            //minus 1 health
            health -= 1;
        }
        //If their health is equal to 0 they die
        if (health<=0)
        {
            //Destroys the enemy
            Destroy(gameObject);
           
        }
    }
    


}
