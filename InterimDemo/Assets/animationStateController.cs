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
        isWalkingHash = Animator.StringToHash("isWalking");
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        //bool walkCheck = Input.GetButtonDown("Switch1");
        Debug.Log(this.GetComponent<NavMeshAgent>().velocity.magnitude);
        Debug.Log(isWalking);

        if (!isWalking && this.GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (isWalking && !(this.GetComponent<NavMeshAgent>().velocity.magnitude > 0.1f))
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
