using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    public GameObject powerupPrefab;
    private float spawnRangeX = 25f;
    private float spawnRangeZ = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Generate random spawn position for powerups and enemies
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(-spawnRangeZ, spawnRangeZ);
        return new Vector3(xPos, 3, zPos);
    }

    void SpawnEntity(String entityName)
    {
        switch(entityName)
        {
            case "powerup":
            
            break;
        }
    }
}
