using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{

    private Spawner spawn;
    public Image healthBar; 
    [SerializeField] private float maxHealth = 100;
    private float curHealth;

    public event Action<float> OnHealthPctChanged = delegate { };


    private void Start()
    {
        spawn = GameObject.Find("Spawners").GetComponent<Spawner>();
    }
    private void Update()
    {
        if (curHealth < 0)
        {
            Die();
        }
    }
    private void OnEnable()
    {
        curHealth = maxHealth;
    }
    public void TakeDamage(Vector3 shootingPosition, int shootingStrength)
    {
        Vector3 shootingDirection = transform.position - shootingPosition;
        Debug.DrawRay(shootingPosition, shootingDirection, Color.red, 5);
        Vector3 shootingForce = shootingDirection.normalized * shootingStrength;
        GetComponent<Rigidbody>().AddForce(shootingForce, ForceMode.Impulse);

        ModifyHealth(-10);
    }

    public void ModifyHealth(int amount)
    {
        curHealth += amount;

        healthBar.fillAmount = curHealth / maxHealth;
        float curHealthPct = (float)curHealth / (float)maxHealth;
        OnHealthPctChanged(curHealthPct);
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Score.scoreValue += 10;
        spawn.KillZombie();
    }
}
