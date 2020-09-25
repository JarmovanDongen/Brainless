using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public int moveSpeed = 5;
    public int maxDist = 10;
    public int minDist = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= maxDist)
        {

        }
    }
}

