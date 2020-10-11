using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    float moveSpeed;
    float walkSpeed = 4;
    float sprintSpeed = 6;
    float jumpSpeed = 20;
    float gravity = 1;

    Vector3 moveDir;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

     void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDir = new Vector3(moveX, 0, moveZ);
            if (Input.GetKey(KeyCode.LeftShift) && moveZ == 1)
            {
                moveSpeed = sprintSpeed;
            }
            else
            {
                moveSpeed = walkSpeed;
            }
            moveDir *= moveSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDir.y += jumpSpeed;
            }
        }
        moveDir.y -= gravity;
        controller.Move(moveDir * Time.deltaTime);
    }
}
