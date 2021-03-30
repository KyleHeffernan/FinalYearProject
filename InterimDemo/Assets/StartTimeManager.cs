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



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((statusCounters.WorkingHours.value + 20) < (Time.time - startTime))
        {
            timePanel.SetActive(false);
            statsPanel.SetActive(false);
            camPanel1.SetActive(false);
            camPanel2.SetActive(false);
            endPanel.SetActive(true);
        }
    }
}
