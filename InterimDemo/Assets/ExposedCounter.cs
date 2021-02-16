using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExposedCounter : MonoBehaviour
{
    Text text;
    private int exposedCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text="Exposed: " + exposedCounter;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] exposed = GameObject.FindGameObjectsWithTag("Exposed");
        int exposedCounter = exposed.Length;
        text.text="Exposed: " + exposedCounter;
        
    }
}
