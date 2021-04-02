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

    //public GameObject StatusCounters;

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
}
