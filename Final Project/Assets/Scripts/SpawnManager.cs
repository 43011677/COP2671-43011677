using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    public float minSpawnDelay = 1.0f;
    public float maxSpawnDelay = 3.0f; 
    
    public float gameTime = 0;

    private playerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
        StartCoroutine(SpawnObstaclesWithRandomDelay());
    }

    IEnumerator SpawnObstaclesWithRandomDelay()
    {
        while (!playerControllerScript.gameOver)
        {
            gameTime = Time.time - mainMenu.returnPressedAt();
            minSpawnDelay = minSpawnDelay - gameTime / 1000;
            maxSpawnDelay = maxSpawnDelay - gameTime / 1000;
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
