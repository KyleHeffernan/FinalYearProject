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

        timeScaleValue.text = "Time Scale: " + timeSlider.value;

        WorkingHoursText.text = "Working Hours: " + WorkingHours.value;
    }
}
