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
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;

        if (distPlayer <= distBrain)
        {

            transform.LookAt(player.transform);
/*            bool playerIsCloseMin = Vector3.Distance(transform.position, player.transform.position) >= minDist;
            bool playerIsCloseMax = Vector3.Distance(transform.position, player.transform.position) <= maxDist;
            if (playerIsCloseMin && playerIsCloseMax)
            {
                
            }*/

        }
        else if (distPlayer > distBrain)
        {
            Vector3 brainPos = new Vector3(brain.transform.position.x, transform.position.y, brain.transform.position.z);
            transform.LookAt(brainPos);
            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            
        }
    }

    void calcDist()
    {
        distPlayer = Vector3.Distance(transform.position, player.transform.position);
        distBrain = Vector3.Distance(transform.position, brain.position);
    }
}

