using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healthPrefab;
    private GameManager gameManager;
    public int enemyCount;
    private int waveNum = 3;
    private int maxWaves = 16;
    private Vector3[] enemySpawnLocs = {new Vector3(-20.5f, 0f, 22f), new Vector3(-14f, 0f, 22f), new Vector3(0f, 0f, 22f),
    new Vector3(4.5f, 0f, 22f), new Vector3(21f, 0f, 22f), new Vector3(22f, 0f, 11.5f), new Vector3(-14.5f, 0f, 13.5f),
    new Vector3(-22f, 0f, 4.5f), new Vector3(22f, 0f, 5.5f), new Vector3(-22f, 0f, -1.5f), new Vector3(-22f, 0f, -10f),
    new Vector3(22f, 0f, -10.5f), new Vector3(3f, 0f, -16f), new Vector3(-2f, 0f, -16f), new Vector3(-22.5f, 0f, -22f),
    new Vector3(-7f, 0f, -22f)}; //possible spawn locations
    private bool[] enemySpawns; //check array
    private Vector3[] pickupSpawnLocs = {new Vector3(0f, 0.5f, 0f), new Vector3(-7f, 0.5f, 4.5f), new Vector3(-6f, 0.5f, 16.5f),
    new Vector3(-15f, 0.5f, -5.75f), new Vector3(-9.2f, 0.5f, -19f), new Vector3(0f, 0.5f, -22f), new Vector3(13f, 0.5f, -4.5f),
    new Vector3(10.5f, 0.5f, 2f), new Vector3(12.5f, 0.5f, 13.5f), new Vector3(-2f, 0.5f, -9f),}; //possible spawn locations
    private bool[] pickupSpawns; //check array

    // Start is called before the first frame update
    void Start()
    {
        //set up companion objects/components
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemySpawns = new bool[enemySpawnLocs.Length];
        pickupSpawns = new bool[pickupSpawnLocs.Length];

        //start the waves
        SpawnWave(waveNum);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            //get the current amount of enemies
            enemyCount = FindObjectsOfType<EnemyTank>().Length;

            //stop the game if the max amount of waves is reached
            if (waveNum == maxWaves)
            {
                gameManager.GameOver();
            }

            //spawn a new wave if all current enemies are gone
            if (enemyCount == 0)
            {
                waveNum++;
                enemySpawns = new bool[enemySpawnLocs.Length];
                pickupSpawns = new bool[pickupSpawnLocs.Length];
                SpawnWave(waveNum);
            }
        }
    }

    //method to generate a unique spawn position for enemies
    private Vector3 GenerateEnemySpawnPos()
    {
        //get an index to choose from
        int arrayLocation = Random.Range(0, enemySpawnLocs.Length - 1);

        //verify that an enemy was not already picked for that location
        if (enemySpawns[arrayLocation] == false)
        {
            enemySpawns[arrayLocation] = true;
            return enemySpawnLocs[arrayLocation];
        }

        //try another position otherwise
        return GenerateEnemySpawnPos();
    }

    //method to generate a unique spawn position for pickups
    private Vector3 GeneratePickupSpawnPos()
    {
        //get an index to choose from
        int arrayLocation = Random.Range(0, pickupSpawnLocs.Length - 1);

        //verify that a pickup was not already picked for that location
        if (pickupSpawns[arrayLocation] == false)
        {
            pickupSpawns[arrayLocation] = true;
            return pickupSpawnLocs[arrayLocation];
        }

        //try another position otherwise
        return GeneratePickupSpawnPos();
    }

    //method to spawn waves based on a given number
    private void SpawnWave(int numEnemies)
    {
        //create the given amount of enemies
        for (int i = 0; i < numEnemies; i++)
        {
            //create the enemy
            Instantiate(enemyPrefab, GenerateEnemySpawnPos(), enemyPrefab.transform.rotation);
        }

        //spawn a health pickup on even rounds
        if (numEnemies % 2 == 0)
        {
            Instantiate(healthPrefab, GeneratePickupSpawnPos(), healthPrefab.transform.rotation);
        }
    }
}
