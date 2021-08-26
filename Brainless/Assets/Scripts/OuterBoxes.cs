using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterBoxes : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<ZombieHealth>().curHealth = 0;
        }
    }
}
