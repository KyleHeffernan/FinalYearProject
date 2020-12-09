using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    

    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            _navMeshAgent.SetDestination(hitInfo.point);

    }
}
