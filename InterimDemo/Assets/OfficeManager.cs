using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeManager : MonoBehaviour
{
    public Slider WorkingHours;
    public float homeTime;

    public Transform Home;

    // Start is called before the first frame update
    void Start()
    {
        homeTime = WorkingHours.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
