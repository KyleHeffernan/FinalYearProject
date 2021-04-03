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
            //If the agent is wearing a mask AND is infectious, change their particlesystem to the mask variant
            if(this.transform.CompareTag("Infectious"))
            {   
                particleSystemNoMask.SetActive(false);
                particleSystemMask.SetActive(true);
            }
        }
        //If agent is healthy and vaccinated, enable the vaccine graphic above them
        if(isVaccinated == true && !this.transform.CompareTag("Infectious"))
        {
            infoCanvas.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Anything marked as a Task is a method used in the behaviour trees

    //Checking if the agent should continue working or go to a rec point
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

    //Checking if the agent is at a rec point should they go back to work
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

    //Checking if the agent has reached their desk
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

    //Setting the agents desk as their destination
    [Task]
    void GoToDesk()
    {
        target = assignedDesk;
        _navMeshAgent.destination = target.transform.position;
        Task.current.Succeed();
    }

    //When the agent is at their desk, make them look forward before they do their 20 seconds of work
    [Task]
    void Work()
    {
        Vector3 lookDirection = -assignedDesk.transform.forward;
        transform.rotation = Quaternion.LookRotation(lookDirection, transform.up);
        Task.current.Succeed();
    }

    //1 in 5 chance that the agent will be set to go to a rec point before their next work session
    [Task]
    void FinishWorkSession()
    {
        if(Random.Range(0, 5) == 1)
        {
            workingCheck = false;
        }
        Task.current.Succeed();

    }

    //Set the target to be a random rec point in the office
    [Task]
    void GetRecTarget()
    {
        target = placeManager.recPoints[Random.Range(0, placeManager.recPoints.Count-1)].transform;
        Task.current.Succeed();
    }

    //Checking if the agent arrived at the rec point
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

    //Setting the agents destination to the rec target
    [Task]
    void GoToRec()
    {
        _navMeshAgent.destination = target.transform.position;
        Task.current.Succeed();
    }
    
    //Before the 10 second wait
    [Task]
    void Rec()
    {
        Task.current.Succeed();
    }

    //After the 10 second wait, set their workingcheck back to true so they will go back to working
    [Task]
    void FinishRec()
    {
        workingCheck = true;
        Task.current.Succeed();
    }

    //Checking if the time passed has gona above working hours
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

    //Set the agents destination to home
    [Task]
    void GoHome()
    {
        _navMeshAgent.destination = placeManager.Home.transform.position;
        Task.current.Succeed();
    }

    //Once the agent has gotten out of the main office, turn off their collider
    [Task]
    void GoneHome()
    {
        if(Vector3.Distance(this.transform.position, placeManager.Home.transform.position) < 42)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
        Task.current.Succeed();
    }
    
}
