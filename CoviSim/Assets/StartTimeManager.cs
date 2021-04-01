using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimeManager : MonoBehaviour
{
    public float startTime;

    public StatusCounters statusCounters;

    public GameObject timePanel;
    public GameObject statsPanel;
    public GameObject camPanel1;
    public GameObject camPanel2;

    public GameObject endPanel;

    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((statusCounters.WorkingHours.value + 25) < (Time.time - startTime))
        {
            timePanel.SetActive(false);
            statsPanel.SetActive(false);
            camPanel1.SetActive(false);
            camPanel2.SetActive(false);
            //player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<Movement>().enabled = false;
            endPanel.SetActive(true);
        }
    }
}
