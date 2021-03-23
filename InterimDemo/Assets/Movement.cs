using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

// This script moves the character controller forward
// and sideways based on the arrow keys.

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float moveSpeed = 0.0f;
    public float gravity = 20.0f;
    public float rotSpeed = 180.0f;
    
    public float walkSpeed = 6.0f;
    public float maxSpeed = 0.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime, 0);//get new rotation
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
            moveDirection = this.transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime;

            if (Input.GetAxis("Vertical") != 0)//If input then move
            {

                moveSpeed = walkSpeed;
            }
            else//if stop pressing then slow down
            {
                if(moveSpeed > 0.0f || moveSpeed > maxSpeed)//stop slowing at 0
                {
                    moveSpeed = 0.0f;
                }
            }

        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
        this.transform.Rotate(this.rotation * Time.deltaTime);
    }//End update
}
