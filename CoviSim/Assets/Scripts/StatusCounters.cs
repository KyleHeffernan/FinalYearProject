using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusCounters : MonoBehaviour
{
    //TextMeshPros and other GUI elements which will be updated as the simulation runs
    public TextMeshProUGUI exposedText;
    public TextMeshProUGUI healthyText;
    public TextMeshProUGUI infectiousText;

    public Slider WorkingHours;
    public TextMeshProUGUI WorkingHoursText;

    public Slider timeSlider;

    public TextMeshProUGUI timeScaleValue;

    public TextMeshProUGUI ElapsedTime;

    public TextMeshProUGUI TimeLeft;

    public StartTimeManager startTimeManager;

    public TextMeshProUGUI fpsDisplay;


    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Finding all of the objects with their respective tags and constantly updating the display
        GameObject[] exposed = GameObject.FindGameObjectsWithTag("Exposed");
        exposedText.text="Exposed: " + exposed.Length;

        GameObject[] healthy = GameObject.FindGameObjectsWithTag("Healthy");
        healthyText.text="Healthy: " + healthy.Length;

        GameObject[] infectious = GameObject.FindGameObjectsWithTag("Infectious");
        infectiousText.text="Infectious: " + infectious.Length;

        //Display the value when the user is adjusting the timescale slider
        timeScaleValue.text = "Time Scale: " + Mathf.Round(timeSlider.value);
        //Display the value when the user is adjusting the working hours slider
        WorkingHoursText.text = "Employee working hours: " + Mathf.Max(Mathf.Round(WorkingHours.value / 60), 1);
        //Display the time passed and time left of the workers shift
        ElapsedTime.text = "Elapsed Time: " + Mathf.Round(Time.time - startTimeManager.startTime);
        TimeLeft.text = "Shift Ends: " + Mathf.Clamp(Mathf.Round(WorkingHours.value - (Time.time - startTimeManager.startTime)), 0, 10000);

        
        //Updating the FPS display
        float fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "FPS: " + Mathf.Round(fps);
        
    }
}
