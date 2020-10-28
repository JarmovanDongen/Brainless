using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    private Spawner spawn;
    public Image healthBar; 
    [SerializeField] public float maxHealth = 100;
    public float curHealth;

    public event Action<float> OnHealthPctChanged = delegate { };


    private void Start()
    {
        spawn = GameObject.Find("Spawners").GetComponent<Spawner>();
    }
    private void Update()
    {
        if (curHealth < 0)
        {
            Destroy(this.gameObject);
            
        }

        
    }
    private void OnEnable()
    {
        curHealth = maxHealth;
    }
    public void TakeDamage(Vector3 shootingPosition, int shootingStrength)
    {
        Vector3 shootingDirection = transform.position - shootingPosition;
        //Debug.DrawRay(shootingPosition, shootingDirection, Color.red, 5);
        Vector3 shootingForce = shootingDirection.normalized * shootingStrength;
        GetComponent<Rigidbody>().AddForce(shootingForce, ForceMode.Impulse);
    }

    public void ModifyHealth(int amount)
    {
        curHealth += amount;
        Debug.Log(curHealth);
        healthBar.fillAmount = curHealth / maxHealth;
        float curHealthPct = (float)curHealth / (float)maxHealth;
        OnHealthPctChanged(curHealthPct);
    }

    public void OnDestroy()
    {
        PowerUps powerUp = GameObject.Find("PowerUpManager").GetComponent<PowerUps>();
        powerUp.CheckDropRateDamage(transform);
        powerUp.CheckDropRateSpeed(transform);
        Score.scoreValue += 10;
        spawn.KillZombie();
    }
}
