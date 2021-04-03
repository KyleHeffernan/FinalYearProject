using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

// This script moves the character controller forward
// and sideways based on the arrow keys.
// It also jumps when pressing space.
// Make sure to attach a character controller to the same game object.
// It is recommended that you make only one call to Move or SimpleMove per frame.

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float rotSpeed = 180.0f;
    
    public float walkSpeed = 6.0f;

    public float gravAmount = -5.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;

    //private bool groundedPlayer;

    //private CharacterController controller;

    //private Vector3 playerVelocity;

    //private float playerSpeed = 10.0f;

    //private float jumpHeight = 1.0f;

    //private float gravityValue = -5f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        Vector3 moveRotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotSpeed, 0);//get new rotation
        
        moveDirection = new Vector3(0.0f, gravAmount, Input.GetAxis("Vertical"));
        moveDirection = this.transform.TransformDirection(moveDirection) * walkSpeed * Time.deltaTime;

        

        // Move the controller
        characterController.Move(moveDirection * (Time.deltaTime * 1 / Time.timeScale));
        this.transform.Rotate(moveRotation * (Time.deltaTime * 1 / Time.timeScale));
    }
    
    /*
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    */
}
