using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Creates an array of different spawn points. By entering the amount of spawnpoints you want in the editor new spawnpoints slots will be available to drag new game objects as spawnpoints in
    public Transform[] spawnPoints;
    //Allows the prefab Enemy to be spawned
    public GameObject Enemy;
    private int RandomSpawn;
    [SerializeField]
    private float SpawnTime=25;
    // Start is called before the first frame update
    void Start()
    {
        //Every x amount of seconds in this case 100 the sub spawn enemy is called 
        InvokeRepeating("SpawnEnemy", 0f, SpawnTime);  
    }

    void SpawnEnemy()
    {
        //Randomizes which spawnpoint will be chosen. This is repeating each look
        RandomSpawn = Random.Range(0, spawnPoints.Length);
        //An enemy is spawned at the random spawn point chosen, with the correct rotation in respect to the spawn point
        Instantiate(Enemy, spawnPoints[RandomSpawn].position, Quaternion.identity);
    }


}
