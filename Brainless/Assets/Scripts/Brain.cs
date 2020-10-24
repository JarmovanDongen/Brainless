using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    public float brainMaxHealth = 1000;
    public float brainCurHealth;
    // Start is called before the first frame update
    void Start()
    {
        brainCurHealth = brainMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            brainCurHealth -= 60 * Time.deltaTime;

        }
        else
            brainCurHealth += 10 * Time.deltaTime;
        
    }
}
