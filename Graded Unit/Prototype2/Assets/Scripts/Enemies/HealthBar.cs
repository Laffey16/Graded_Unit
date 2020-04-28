using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    private EnemyBehaviour EnemyObj;
    int health;
    private void Update()
    {
        SetHealth();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Gets access to the enemy prefab
        EnemyObj = GameObject.FindObjectOfType<EnemyBehaviour>();
        SetMaxHealth();
    }
    public void SetMaxHealth()
    {
        health = EnemyObj.health;
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth()
    {
        slider.value = EnemyObj.health;
    }
}


   
