using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnPickUp : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TextSpawner text = GameObject.Find("Text").GetComponent<TextSpawner>();
            text.SpawnText();
            Shooting shooting = other.gameObject.GetComponent<Shooting>();
            shooting.damage += 5;
            Destroy(gameObject);
        }
       
    }
}
