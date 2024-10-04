using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    void Start()
    {
        StartCoroutine(SpawnTarget()); 
    }

    IEnumerator SpawnTarger() {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    void Update()
    {
        
    }
}
