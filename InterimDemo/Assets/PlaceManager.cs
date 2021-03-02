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
        PopulateLists();
        //availableDesks = new List<GameObject>();
        //recPoints = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopulateLists()
    {
        GameObject[] desks = GameObject.FindGameObjectsWithTag("Chair");
        foreach (var ob in desks)
        {
            availableDesks.Add(ob);
        }

        GameObject[] recs = GameObject.FindGameObjectsWithTag("Rec");
        foreach (var ob in recs)
        {
            recPoints.Add(ob);
        }
    }
}
