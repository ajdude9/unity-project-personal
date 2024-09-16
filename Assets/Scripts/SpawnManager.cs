using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    public GameObject powerupPrefab;
    public GameObject[] enemyList;
    private float spawnRangeX = 25f;
    private float spawnRangeZ = 25f;
    private int waveCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        detectPowerups();        
        enemyWaveHandler();
    }

    // Generate random spawn position for powerups and enemies
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(xPos, 3, zPos);
    }

    void SpawnEntity(String entityName, int entityNum)
    {
        switch(entityName)
        {
            case "powerup":
                Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0,0,0), Quaternion.Euler(new Vector3(Random.Range(1, 15), Random.Range(0, 360), 0)));
            break;
            case "slime":
                Instantiate(enemyList[entityNum], GenerateSpawnPosition() + new Vector3(0,0,0), transform.rotation);
            break;            
        }
    }

    void detectPowerups()
    {
        int powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;

        if (powerupCount == 0)
        {
            SpawnEntity("powerup", 0);
        }
    }

    void SpawnEnemyWave(int count)
    {
        for(int i = 0; i < count; i++)
        {
            SpawnEntity("slime", Random.Range(0, 3));            
        }
    }

    void enemyWaveHandler()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemyCount < 1)
        {
            waveCount++;
            SpawnEnemyWave(waveCount);
        }
    }
}
