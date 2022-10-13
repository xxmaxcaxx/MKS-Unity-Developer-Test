using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemys;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = MainMenu.spawnTime;
        if (spawnTime == 0)
        {
            spawnTime = 3.0f;
        }
        InvokeRepeating("SpawnEnemies", spawnTime, spawnTime);
    }

    void SpawnEnemies()
    {
        int index = Random.Range(0, spawnPoints.Length);
        int index2 = Random.Range(0, enemys.Length);
        Instantiate(enemys[index2], spawnPoints[index].position, Quaternion.identity);
    }
}
