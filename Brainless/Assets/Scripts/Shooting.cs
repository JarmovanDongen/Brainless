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
    public int damage = 10;

    public AudioSource leafBlowerSFX;

    // Start is called before the first frame update
    void Start()
    {
        leafBlowerSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting();
            leafBlowerSFX.Play();
        }
    }

    void shooting()
    {
        Quaternion leafBlowerRotation =leafBlower.transform.rotation * Quaternion.Euler(90,0,0);
        shootingPosition = leafBlower.transform.position + (leafBlowerRotation * new Vector3(0, 0, 0));
        RaycastHit hit;
        Vector3 direction = leafBlowerRotation * new Vector3(0,0,1);
        
        Debug.DrawRay(shootingPosition, direction, Color.red, 5000);
        bool hasCollided = Physics.Raycast(shootingPosition, direction, out hit, shootingRange, LayerMask.NameToLayer("LeafBlower"));
        
        if (hasCollided)
        {
            GameObject zombie = hit.collider.gameObject;
            zombie.GetComponent<ZombieHealth>().TakeDamage(shootingPosition, shootingStrength);
            zombie.GetComponent<ZombieHealth>().ModifyHealth(-damage);
        }

    }


}
