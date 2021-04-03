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

    private int runOnce = 0;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if((statusCounters.WorkingHours.value + 25) < (Time.time - startTime) && runOnce == 0)
        {
            runOnce = 1;

            timePanel.SetActive(false);
            statsPanel.SetActive(false);
            camPanel1.SetActive(false);
            camPanel2.SetActive(false);
            tipPanel.SetActive(false);
            player.GetComponent<Movement>().enabled = false;
            endPanel.SetActive(true);

            GameObject[] exposedList = GameObject.FindGameObjectsWithTag("Exposed");
            exposedFinal.text = exposedList.Length + " out of 20 workers were exposed";

            GameObject[] contaminatedList = GameObject.FindGameObjectsWithTag("Contaminated");
            contaminated.text = contaminatedList.Length + " items were contaminated";
        }
    }
}
