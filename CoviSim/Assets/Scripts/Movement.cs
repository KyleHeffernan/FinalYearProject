using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float rotSpeed = 180.0f;
    
    public float walkSpeed = 6.0f;

    public float gravAmount = -5.0f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 rotation;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    void FixedUpdate()
    {
        //Getting rotation
        Vector3 moveRotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotSpeed, 0);
        //Getting movement
        moveDirection = new Vector3(0.0f, gravAmount, Input.GetAxis("Vertical"));
        moveDirection = this.transform.TransformDirection(moveDirection) * walkSpeed * Time.deltaTime;

        //Apply changes to the character controller
        characterController.Move(moveDirection * (Time.deltaTime * 1 / Time.timeScale));
        this.transform.Rotate(moveRotation * (Time.deltaTime * 1 / Time.timeScale));
    }
    
}
