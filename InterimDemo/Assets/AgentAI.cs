using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentAI : MonoBehaviour
{
    public SimplePath path;
    private NavMeshAgent _navMeshAgent;
    

    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) &&
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
            _navMeshAgent.SetDestination(hitInfo.point);


        if(Vector3.Distance(this.transform.position, _navMeshAgent.destination) < 1)
        {
            _navMeshAgent.SetDestination(path.NextWaypoint());
        }

    }
}
