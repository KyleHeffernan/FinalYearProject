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

    public Toggle maskToggle1;
    public bool wearingMask;

    public Toggle vaccineToggle;
    public bool isVaccinated;

    public GameObject maskObject;

    public float lastHit = 0;

    public GameObject particleSystemNoMask;

    public GameObject particleSystemMask;

    public GameObject infoCanvas;


    private void Awake() => _navMeshAgent = GetComponent<NavMeshAgent>();

    // Start is called before the first frame update
    void Start()
    {
        //Each agent gets assigned a random desk and removes it from the list so no agents will get the same desk
        assignedDesk = placeManager.availableDesks[Random.Range(0, placeManager.availableDesks.Count-1)].transform;
        placeManager.availableDesks.Remove(assignedDesk.gameObject);
        //Saving the time the agents spawn
        startTime = Time.time;
        //Saving the workers hift time
        homeTime = WorkingHours.value;
        //Change mask toggle based on what user selected
        if(this.transform.CompareTag("Infectious"))
        {
            wearingMask = maskToggle1.isOn;
        }
        else
        {
            wearingMask = maskToggle.isOn;
        }
        //Change vaccine toggle to what user selected
        isVaccinated = vaccineToggle.isOn;
        //If not wearing mask, disable mask object
        if(wearingMask == false)
        {
            maskObject.SetActive(false);
        }
        else
        {
            if(this.transform.CompareTag("Infectious"))
            {   
                particleSystemNoMask.SetActive(false);
                particleSystemMask.SetActive(true);
            }
        }
        if(isVaccinated == true && !this.transform.CompareTag("Infectious"))
        {
            infoCanvas.SetActive(true);
        }

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
        if(Vector3.Distance(this.transform.position, placeManager.Home.transform.position) < 42)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            //gameObject.GetComponent<Renderer>().enabled = false;
        }
        Task.current.Succeed();
    }
    
}
