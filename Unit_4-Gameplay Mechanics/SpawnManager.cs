using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount = 1;
    public int waveNumber = 1;
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    public GameObject powerupPrefab;
    void Start()
    {
        spawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn){
        for (int i = 0; int < enemiesToSpawn; int++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<enemyCount>().Length;
        if (enemyCount == 0)
         { 
            waveNumber ++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
         }
    }
}
