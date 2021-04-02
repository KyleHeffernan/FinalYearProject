using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject camera1;

    public GameObject camera2;

    public GameObject camera3;

    public GameObject camera4;

    public GameObject panel1;

    public GameObject panel2;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Switch1"))
        {
            panel1.SetActive(true);
            panel2.SetActive(false);
            camera1.SetActive(true);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if(Input.GetButtonDown("Switch2"))
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(true);
            camera3.SetActive(false);
            camera4.SetActive(false);
        }
        if(Input.GetButtonDown("Switch3"))
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(true);
            camera4.SetActive(false);
        }
        
        if(Input.GetButtonDown("Switch4"))
        {
            panel1.SetActive(false);
            panel2.SetActive(true);
            camera1.SetActive(false);
            camera2.SetActive(false);
            camera3.SetActive(false);
            camera4.SetActive(true);
        }
        


    }
}
