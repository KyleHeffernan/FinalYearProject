using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform cam;
    public float lerpSpeed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos;//For holding point to look
        
        relativePos = cam.transform.position - transform.position;
        
        //For holding new rotation
        Quaternion toRotation = Quaternion.LookRotation(relativePos, cam.transform.up);
        //Lerps the vaccine icon to face the player
        transform.rotation = Quaternion.Lerp( transform.rotation, toRotation, lerpSpeed * Time.deltaTime );

    }
}
