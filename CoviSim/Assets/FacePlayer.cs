using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    private Transform cam;
    public float lerpSpeed = 5;
    public bool reverseDir = false;//Need this because some things such as guis face forward in wrong direction
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos;//For holding point to look
        
        if (reverseDir)//Flip direction
        {
            relativePos = transform.position - cam.transform.position;
        }
        else
        {
            relativePos = cam.transform.position - transform.position;
        }
        
        Quaternion toRotation = Quaternion.LookRotation(relativePos, cam.transform.up);//For holding new rotation
        transform.rotation = Quaternion.Lerp( transform.rotation, toRotation, lerpSpeed * Time.deltaTime );

    }
}
