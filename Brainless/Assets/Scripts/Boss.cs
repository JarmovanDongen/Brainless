using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public Transform brain;

    public int moveSpeed = 3;
    public int maxDist = 10;
    public int minDist = 5;
    public float distBrain, distPlayer;

    public Image healthBar;
    [SerializeField] public float maxBossHealth = 1000;
    public float curBossHealth;
    public event Action<float> OnHealthPctChanged = delegate { };
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FirstPersonPlayer");
        brain = GameObject.Find("Brain").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        calcDist();
        Movement();
    }

    void Movement()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;

        if (distPlayer <= distBrain)
        {

            transform.LookAt(player.transform);


        }
        else if (distPlayer > distBrain)
        {
            Vector3 brainPos = new Vector3(brain.transform.position.x, transform.position.y, brain.transform.position.z);
            transform.LookAt(brainPos);


        }
    }


    void calcDist()
    {
        distPlayer = Vector3.Distance(transform.position, player.transform.position);
        distBrain = Vector3.Distance(transform.position, brain.position);
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
}
