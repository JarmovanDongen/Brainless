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
    public Transform brain;
    public float distBrain, distPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonPlayer");
        brain = GameObject.Find("Brain").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        calcDist();
    }

    void Movement()
    {
        

        if (distPlayer <= distBrain)
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
        else if (distPlayer > distBrain)
        {
            transform.LookAt(brain.transform);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }

    }

    void calcDist()
    {
        distPlayer = Vector3.Distance(transform.position, player.transform.position);
        distBrain = Vector3.Distance(transform.position, brain.position);
    }
}

