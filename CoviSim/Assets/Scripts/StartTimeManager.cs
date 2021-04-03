using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartTimeManager : MonoBehaviour
{
    public float startTime;

    public StatusCounters statusCounters;

    public GameObject timePanel;
    public GameObject statsPanel;
    public GameObject camPanel1;
    public GameObject camPanel2;

    public GameObject endPanel;

    public GameObject tipPanel;

    public GameObject player;

    public TextMeshProUGUI exposedFinal;
    public TextMeshProUGUI contaminated;

    public TextMeshProUGUI vaccinated;

    public TextMeshProUGUI healthyMask;

    public TextMeshProUGUI infectedMask;

    public TextMeshProUGUI workingHours;

    public Slider workingHoursSlider;

    public Toggle maskToggle;

    public Toggle maskToggle1;

    public Toggle vaccineToggle;

    private int runOnce = 0;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        player.GetComponent<Movement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //25 seconds after the workers shift has finished, giving them time to leave
        if((statusCounters.WorkingHours.value + 25) < (Time.time - startTime) && runOnce == 0)
        {
            //Only run following code as values will not change
            runOnce = 1;
            //Disabling other GUI and showing end screen
            timePanel.SetActive(false);
            statsPanel.SetActive(false);
            camPanel1.SetActive(false);
            camPanel2.SetActive(false);
            tipPanel.SetActive(false);
            player.GetComponent<Movement>().enabled = false;
            endPanel.SetActive(true);
            //Updating the end screen stats
            GameObject[] exposedList = GameObject.FindGameObjectsWithTag("Exposed");
            exposedFinal.text = exposedList.Length + " out of 20 workers were exposed";

            GameObject[] contaminatedList = GameObject.FindGameObjectsWithTag("Contaminated");
            contaminated.text = contaminatedList.Length + " items were contaminated";

            workingHours.text = "Employee working hours: " + Mathf.Max(Mathf.Round(workingHoursSlider.value / 60), 1);

            if(maskToggle.isOn)
            {
                healthyMask.text ="Healthy workers were wearing masks";
            }
            else
            {
                healthyMask.text ="Healthy workers were not wearing masks";
            }

            if(maskToggle1.isOn)
            {
                infectedMask.text ="The infected worker was wearing a mask";
            }
            else
            {
                infectedMask.text ="The infected worker was not wearing a mask";
            }

            if(vaccineToggle.isOn)
            {
                vaccinated.text ="Healthy workers were vaccinated";
            }
            else
            {
                vaccinated.text ="Healthy workers were not vaccinated";
            }

        }
    }
}
