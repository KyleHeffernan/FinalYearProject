using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        //bool walkCheck = Input.GetButtonDown("Switch1");
        

        if (!isWalking && this.GetComponent<Rigidbody>().velocity.magnitude > 0.8f)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !(this.GetComponent<Rigidbody>().velocity.magnitude > 0.8f))
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
