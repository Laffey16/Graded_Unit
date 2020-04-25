using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Enemy;
    private int RandomSpawn;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemy", 0f, 100f);  
    }

    void SpawnEnemy()
    {

        RandomSpawn = Random.Range(0, spawnPoints.Length);
        
        Instantiate(Enemy, spawnPoints[RandomSpawn].position, Quaternion.identity);
    }


}
