using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float force = 50f;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
        if (player != null)
        {
            rigid.AddForce(new Vector3(force, force, 0));
        }
    }
}
