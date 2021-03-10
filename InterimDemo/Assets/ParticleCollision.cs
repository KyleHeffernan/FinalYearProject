using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Material Exposed;
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = particle.GetCollisionEvents(other, collisionEvents);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while(i < numCollisionEvents)
        {

            if(rb != null)
            {
                if(!other.transform.CompareTag("Infectious"))
                {
                    other.GetComponent<MeshRenderer>().material = Exposed;
                    other.gameObject.tag = "Exposed";
                }

            }
            else
            {
                other.GetComponent<MeshRenderer>().material = Exposed;


                /* 
                var myMaterials = other.GetComponent<MeshRenderer>().materials;
                foreach(var material in myMaterials)
                {
                    material = Exposed;
                }
                */
                
            }
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
