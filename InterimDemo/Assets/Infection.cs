using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public Material Healthy;
    public Material Exposed;

    public Material Infectious;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "test")
        {
            this.gameObject.tag = "Exposed";
            this.GetComponent<MeshRenderer>().material = Exposed;
        }
    }

    /*
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "MainCamera" && enemyTank.GetComponent<TankController>().enabled == true)
        {
            collider.gameObject.transform.position = Vector3.Lerp(

                collider.gameObject.transform.position
                , transform.position
                , Time.deltaTime * 3
                );
            collider.gameObject.transform.rotation = Quaternion.Slerp(
                collider.gameObject.transform.rotation
                , transform.parent.rotation
                , Time.deltaTime
                );
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyTank.GetComponent<TankController>().enabled = false;
            enemyTank.GetComponent<AITank>().enabled = true;
            collider.gameObject.GetComponent<FPSController>().enabled = true;
            GetComponent<RotateMe>().enabled = true;
        }
	}
    */
}
