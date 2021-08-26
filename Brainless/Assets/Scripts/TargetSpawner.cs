using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{

    public List<GameObject> targetSpawns = new List<GameObject>();

    public int activeSpawn;

    public void Start()
    {
        for (int i = 0; i < targetSpawns.Count; i++)
        {
            targetSpawns[i].SetActive(false);
        }
    }
    public void enableRandomTarget()
    {
        int randomSpawn = Random.Range(0, targetSpawns.Count);

        while (randomSpawn == activeSpawn)
        {
            randomSpawn = Random.Range(0, targetSpawns.Count);
        }
        targetSpawns[activeSpawn].SetActive(false);
        targetSpawns[randomSpawn].SetActive(true);
        activeSpawn = randomSpawn;
    }


    public void disableSpawner()
    {
        for (int i = 0; i < targetSpawns.Count; i++)
        {
            targetSpawns[i].SetActive(false);
        }
    }
}
