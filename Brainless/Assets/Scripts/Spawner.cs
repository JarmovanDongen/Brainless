using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public int waveNumber = 0;
    private int enemySpawnAmount = 0;
    private int enemiesKilled = 0;
    public GameObject[] spawners;
    public GameObject enemy;
    public GameObject boss;
    public GameObject bossSpawnPoint;
    public TargetSpawner spawner;
    public ZombieHealth health;

    public AudioSource waveBell;
    // Start is called before the first frame update
    void Start()
    {
        spawners = new GameObject[4];
        waveBell = GetComponent<AudioSource>();
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

    private void SpawnEnemy(int healthIncrease = 0)
    {
        int spawnerID = Random.Range(0, spawners.Length);
        GameObject healthIncrement = Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
        
        ZombieHealth ZombieScript = healthIncrement.GetComponent<ZombieHealth>();
        ZombieScript.maxHealth += healthIncrease;
        ZombieScript.curHealth = ZombieScript.maxHealth;
    }

   

    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = 2;
        enemiesKilled = 0;
        waveBell.Play();
        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void WaveIncrement()
    {
        if (waveNumber == 4 || waveNumber == 9 || waveNumber == 14)
        {
            BossSpawn();
            spawner.enableRandomTarget();
            waveNumber++;
            enemiesKilled = 0;
        }
        else
        {
            spawner.disableSpawner();
            waveNumber++;
            enemySpawnAmount += 1;
            enemiesKilled = 0;
            waveBell.Play();
            for (int i = 0; i < enemySpawnAmount; i++)
            {
                SpawnEnemy(30);
            }
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
    private void BossSpawn(int bossHealthIncrease = 0)
    {
        GameObject BossSpawn = Instantiate(boss, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);
    }
}
