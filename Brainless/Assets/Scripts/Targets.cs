using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targets : MonoBehaviour
{
    public TargetSpawner spawner;
    public int damage = 250;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("TagetSpawners").GetComponent<TargetSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<ZombieHealth>().ModifyHealth(-damage);
            spawner.enableRandomTarget();
        }
    }
}
