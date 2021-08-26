using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float x;
    public float z;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    private void Update()
    {
         x = Input.GetAxisRaw("Horizontal");
         z = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        //Checks if the player is standing on the ground to set the velocity to 0
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        //Moves the player in the direction it is looking
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move.normalized * speed * Time.deltaTime);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //Adds the gravity to the player
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void SpeedBoost()
    {
        speed += 10;
       StartCoroutine("Timer");
    }

    public IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        speed -= 10;
    }
}
