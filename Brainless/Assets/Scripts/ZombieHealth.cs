using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    private Spawner spawn;
    public Image healthBar;
    [SerializeField] public float maxHealth = 1000;
    public float curHealth;

    public event Action<float> OnHealthPctChanged = delegate { };
    public Rigidbody rb;

    private void Start()
    {
        spawn = GameObject.Find("Spawners").GetComponent<Spawner>();
    }
    private void Update()
    {

        if (curHealth <= 0)
        {
            if (CompareTag("Boss"))
            {
                
                spawn.WaveIncrement();
            }
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
        //rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -0.01f, 0.01f), Mathf.Clamp(rb.velocity.y, -0.01f, 0.01f), Mathf.Clamp(rb.velocity.z, -0.01f, 0.01f));
        rb.AddForce(shootingForce * 2, ForceMode.Force);
        //Debug.Log(shootingForce);

        //GetComponent<Rigidbody>().AddForce(shootingForce, ForceMode.Impulse);
    }

    public void ModifyHealth(float amount)
    {
        curHealth += amount;
        Debug.Log(amount);
        healthBar.fillAmount = curHealth / maxHealth;
        float curHealthPct = curHealth / maxHealth;
        OnHealthPctChanged(curHealthPct);
    }

    public void OnDestroy()
    {
        PowerUps powerUp = GameObject.Find("PowerUpManager").GetComponent<PowerUps>();
        powerUp.CheckDropRateDamage(transform);
        powerUp.CheckDropRateSpeed(transform);
        Score.scoreValue += 10;
        Debug.Log(spawn);
        spawn.KillZombie();
    }
}
