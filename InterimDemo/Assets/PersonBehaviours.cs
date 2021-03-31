using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UI;

public class PersonBehaviours : MonoBehaviour
{
    public Transform target;

    public PlaceManager placeManager;

    public Transform assignedDesk;

    public bool workingCheck = true;

    private NavMeshAgent _navMeshAgent;

    private float startTime;

    public Slider WorkingHours;

    private float homeTime;

    public Toggle maskToggle;
    public bool wearingMask;

    public GameObject maskObject;

    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();

    // Start is called before the first frame update
    void Start()
    {
        assignedDesk = placeManager.availableDesks[Random.Range(0, placeManager.availableDesks.Count-1)].transform;
        placeManager.availableDesks.Remove(assignedDesk.gameObject);
        startTime = Time.time;
        homeTime = WorkingHours.value;
        wearingMask = maskToggle.isOn;
        if(wearingMask == false)
        {
            maskObject.SetActive(false);
        }
        //Debug.Log(wearingMask);
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Task]
    void CheckWorking()
    {
        if(workingCheck == true)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }

    }

    [Task]
    void CheckOnBreak()
    {
        if(workingCheck == false)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }

    }

    [Task]
    void CheckAtDesk()
    {
        if(Vector3.Distance(this.transform.position, assignedDesk.transform.position) < 0.1f)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }

    [Task]
    void GoToDesk()
    {
        target = assignedDesk;
        _navMeshAgent.destination = target.transform.position;
        Task.current.Succeed();
    }

    [Task]
    void Work()
    {
        Vector3 lookDirection = -assignedDesk.transform.forward;
        transform.rotation = Quaternion.LookRotation(lookDirection, transform.up);
        //this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        Task.current.Succeed();
    }

    [Task]
    void FinishWorkSession()
    {
        if(Random.Range(0, 5) == 1)
        {
            workingCheck = false;
        }
        Task.current.Succeed();

    }



    [Task]
    void GetRecTarget()
    {
        target = placeManager.recPoints[Random.Range(0, placeManager.recPoints.Count-1)].transform;
        Task.current.Succeed();
    }

    [Task]
    void CheckAtRec()
    {
        if(Vector3.Distance(this.transform.position, target.transform.position) < 1)
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }

    [Task]
    void GoToRec()
    {
        _navMeshAgent.destination = target.transform.position;
        Task.current.Succeed();
    }

    [Task]
    void Rec()
    {
        Task.current.Succeed();
    }

    [Task]
    void FinishRec()
    {
        workingCheck = true;
        Task.current.Succeed();
    }

    [Task]
    void CheckHome()
    {
        if(homeTime < (Time.time - startTime))
        {
            Task.current.Succeed();
        }
        else
        {
            Task.current.Fail();
        }
    }

    [Task]
    void GoHome()
    {
        _navMeshAgent.destination = placeManager.Home.transform.position;
        Task.current.Succeed();
    }

    [Task]
    void GoneHome()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Task.current.Succeed();
    }



    /*
    [Task]
    void CheckReached()
    {
        if(Vector3.Distance(this.transform.position, _navMeshAgent.destination) < 1)
        {
            Task.current.Succeed();

            //_navMeshAgent.SetDestination(path.NextWaypoint());
        }
        else
        {
            Task.current.Fail();
        }
    }

    [Task]
    void SetNew()
    {
        _navMeshAgent.SetDestination(target.transform.position);
        Task.current.Succeed();
    }
    */


    
}
