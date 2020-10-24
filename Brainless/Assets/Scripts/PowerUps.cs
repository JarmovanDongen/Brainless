using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    private GameObject DamagePowerUp;
    public int dropChance = 2;
    // Start is called before the first frame update
    void Start()
    {
        DamagePowerUp = Resources.Load("Assets/Resources/Cube.prefab") as GameObject;
        Debug.Log(Resources.Load("Assets/Prefabs/LeafBlowerWeapon.fbx"));
    }

    // Update is called once per frame
    void Update()
    {
        if (DamagePowerUp == null)
        {
           // Debug.Log("Test");
        }
    }

    public void CheckDropRate(Transform position)
    {
       int i = Random.Range(0, dropChance);
        Debug.Log(i);
        if ( i == dropChance /2)
        {
            Instantiate(DamagePowerUp, transform.position, Quaternion.identity);
            Debug.Log("spawnPowerUp");
        }
    }
}
