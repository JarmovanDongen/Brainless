using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Shooting shooting;
    private GameObject DamagePowerUp;
    private GameObject speedPowerUp;
    public int dropChance = 2;
    // Start is called before the first frame update
    void Start()
    {
        DamagePowerUp = Resources.Load("LeafBlowerWeapon-Variant") as GameObject;
        speedPowerUp = Resources.Load("Shoe") as GameObject;
        Debug.Log(Resources.Load("LeafBlowerWeapon-Variant"));

    }

    public void CheckDropRateDamage(Transform position)
    {
       int i = Random.Range(0, dropChance);
        //Debug.Log(i);
        if ( i == dropChance /2)
        {
            GameObject damPowerUp = Instantiate(DamagePowerUp, position.position, Quaternion.identity);
            damPowerUp.transform.rotation = Quaternion.Euler(-90, 0, 0);
            damPowerUp.transform.position = new Vector3(position.position.x, 3, position.position.z);

        }
    }

    public void CheckDropRateSpeed(Transform position)
    {
        int j = Random.Range(0, dropChance);
        Debug.Log(j);
        if (j == dropChance / 2)
        {
            GameObject speedPU = Instantiate(speedPowerUp, position.position, Quaternion.identity);
            speedPU.transform.rotation = Quaternion.Euler(0, 0, 0);
            speedPU.transform.position = new Vector3(position.position.x, 3, position.position.z);

        }
    }
}
