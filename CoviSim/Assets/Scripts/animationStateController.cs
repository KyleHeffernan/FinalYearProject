using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");// To improve performance
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);

        if (!isWalking && this.GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f)
        {
            animator.SetBool(isWalkingHash, true); // If they're moving, play animation
        }
        if (isWalking && !(this.GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f))
        {
            animator.SetBool(isWalkingHash, false); // If they stop moving, switch to idle animation
        }
    }
}
