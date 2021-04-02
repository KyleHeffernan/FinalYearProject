using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatusCounters : MonoBehaviour
{


    public TextMeshProUGUI exposedText;
    public TextMeshProUGUI healthyText;
    public TextMeshProUGUI infectiousText;

    public Slider WorkingHours;
    public TextMeshProUGUI WorkingHoursText;

    public Slider timeSlider;

    public TextMeshProUGUI timeScaleValue;

    public TextMeshProUGUI ElapsedTime;

    public TextMeshProUGUI TimeLeft;

    public TextMeshProUGUI exposedFinal;

    public StartTimeManager startTimeManager;

    public TextMeshProUGUI fpsDisplay;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] exposed = GameObject.FindGameObjectsWithTag("Exposed");
        exposedText.text="Exposed: " + exposed.Length;

        GameObject[] healthy = GameObject.FindGameObjectsWithTag("Healthy");
        healthyText.text="Healthy: " + healthy.Length;

        GameObject[] infectious = GameObject.FindGameObjectsWithTag("Infectious");
        infectiousText.text="Infectious: " + infectious.Length;

        timeScaleValue.text = "Time Scale: " + Mathf.Round(timeSlider.value);

        WorkingHoursText.text = "Working Hours: " + Mathf.Max(Mathf.Round(WorkingHours.value / 60), 1);

        ElapsedTime.text = "Elapsed Time: " + Mathf.Round(Time.time - startTimeManager.startTime);

        TimeLeft.text = "Time Left: " + Mathf.Clamp(Mathf.Round(WorkingHours.value - (Time.time - startTimeManager.startTime)), 0, 10000);

        exposedFinal.text = exposedText.text;

        float fps = 1 / Time.unscaledDeltaTime;
        fpsDisplay.text = "FPS: " + Mathf.Round(fps);
        
    }
}
