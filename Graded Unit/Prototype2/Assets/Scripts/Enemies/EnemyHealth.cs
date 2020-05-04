using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Script for Universal Enemy Health
public class EnemyHealth : MonoBehaviour
{
    //Sets the enemy health
    public int health = 5;
    //A way to reference the enemies health bar
    public Slider slider;
    private PlayerCharacter PlayerObj;
    
    private void Start()
    {
        //Runs method to set the enemy health bar to max health on spawning
        SetMaxHealth();
        //Accesses the player character script for melee and bullet damages
        PlayerObj = GameObject.FindObjectOfType<PlayerCharacter>();
    }
    public void SetMaxHealth()
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void BulletDamage()
    {
        //If enemy is hit by a bullet takes the damage set by the bullet in the player script
        health -= PlayerObj.BulletDamage;
        //Changes the health bar to reflect the enemies health variable
        slider.value = health;
        //If health is below or equal to 0 then the enemy dies
        if(health<=0)
        {
            Destroy(gameObject);
        }

    }
   public void MeleeDamage()
    {
        //Checks to see if hit by melee
        Debug.Log("Enemy Hit");
        //Takes melee damage (from player script) away from enemy
        health -= PlayerObj.MeleeDamage;
        //Changes the health bar to reflect the enemies health variable
        slider.value = health;
        //If health is below or equal to 0 then the enemy dies
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
