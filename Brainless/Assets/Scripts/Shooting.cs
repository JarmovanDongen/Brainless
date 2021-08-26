using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int shootingStrength;
    public Vector3 shootingPosition;
    public GameObject leafBlower;
    public int shootingRange = 10;
    public float damage = 1;

    [SerializeField] private ParticleSystem particles;
    public AudioSource leafBlowerSFX;

    // Start is called before the first frame update
    void Start()
    {
        leafBlowerSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (!leafBlowerSFX.isPlaying)
            {
                leafBlowerSFX.Play();
            }
            shooting();
            var emission = particles.emission;
            emission.rateOverTime = 120;
        }
        else
        {
            
            var emission = particles.emission;
            emission.rateOverTime = 0;
        }
        
    }

    void shooting()
    {
        Quaternion leafBlowerRotation =leafBlower.transform.rotation * Quaternion.Euler(90,0,0);
        shootingPosition = leafBlower.transform.position + (leafBlowerRotation * new Vector3(0, 0, 0));
        RaycastHit hit;
        Vector3 direction = leafBlowerRotation * new Vector3(0,0,1);
        
        //Debug.DrawRay(shootingPosition, direction, Color.red, 5000);
        bool hasCollidedWithZombie = Physics.Raycast(shootingPosition, direction, out hit, shootingRange, LayerMask.NameToLayer("LeafBlower"));
        if (hasCollidedWithZombie)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                GameObject zombie = hit.collider.gameObject;
                zombie.GetComponent<ZombieHealth>().ModifyHealth(-damage);
                zombie.GetComponent<ZombieHealth>().TakeDamage(shootingPosition, shootingStrength);
            }

            if (hit.collider.CompareTag("Boss"))
            {
                GameObject zombie = hit.collider.gameObject;
                zombie.GetComponent<ZombieHealth>().TakeDamage(shootingPosition, shootingStrength);
            }

        }
    }
}
