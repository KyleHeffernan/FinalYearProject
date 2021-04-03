using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> availableDesks;
    public List<GameObject> recPoints;

    public Transform Home;

    void Awake()
    {
        PopulateLists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PopulateLists()
    {
        //Called on awake, this finds all of the desks in the scene and populates a list
        GameObject[] desks = GameObject.FindGameObjectsWithTag("Chair");
        foreach (var ob in desks)
        {
            availableDesks.Add(ob);
        }
        //Called on awake, this finds all of the recpoints in the scene and populates a list
        GameObject[] recs = GameObject.FindGameObjectsWithTag("Rec");
        foreach (var ob in recs)
        {
            recPoints.Add(ob);
        }
    }
}
