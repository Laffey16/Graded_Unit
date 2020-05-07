using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Creates an array of different spawn points. By entering the amount of spawnpoints you want in the editor new spawnpoints slots will be available to drag new game objects as spawnpoints in
    public Transform[] spawnPoints;
    //Allows the prefab Enemy to be spawned
    public GameObject Enemy;
    public GameObject Slime;
    private int RandomSpawn;
    [SerializeField]
    private float SpawnTime=25;
    private int Enemychooser;
    private GameObject EnemyChosen;
    // Start is called before the first frame update
    void Start()
    {
        //Every x amount of seconds in this case 100 the sub spawn enemy is called 
        InvokeRepeating("SpawnEnemy", 0f, SpawnTime);
    }


    void SpawnEnemy()
    {
        //Chooses a random number between 0 and 1
        Enemychooser = Random.Range(0, 1);
        //If 0 is chosen then a slime spawns
        if (Enemychooser == 0) {
            EnemyChosen = Slime;
        }else if(Enemychooser==1)
        {
            //If 1 is chosen then Enemy spawns
            EnemyChosen = Enemy;
        }
    
        //Randomizes which spawnpoint will be chosen. This is repeating each look
        RandomSpawn = Random.Range(0, spawnPoints.Length);
        //An enemy(chosen previously) is spawned at the random spawn point chosen, with the correct rotation in respect to the spawn point
        Instantiate(EnemyChosen, spawnPoints[RandomSpawn].position, Quaternion.identity);
    }


}
