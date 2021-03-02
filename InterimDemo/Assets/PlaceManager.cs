using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> availableDesks;
    public List<GameObject> recPoints;

    void Awake()
    {
        PopulateDesks();
        //availableDesks = new List<GameObject>();
        //recPoints = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopulateDesks()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Chair");
        foreach (var ob in objs)
        {
            availableDesks.Add(ob);
        }
    }
}
