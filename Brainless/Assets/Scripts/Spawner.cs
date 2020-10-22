using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    private int enemySpawnAmount = 0;
    private int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[4];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = 3;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    private void WaveIncrement()
    {
        waveNumber++;
        enemySpawnAmount += 3;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void KillZombie()
    {
        enemiesKilled++;
        if (enemiesKilled >= enemySpawnAmount)
        {
            WaveIncrement();
        }
    }
}
