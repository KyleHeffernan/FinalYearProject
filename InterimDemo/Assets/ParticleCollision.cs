using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Material Exposed;
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;

    //private List<Material> myMaterials;


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
                other.GetComponentInChildren<MeshRenderer>().material = Exposed;

                /*
                foreach(var material in other.GetComponentInChildren<MeshRenderer>().material)
                {

                }
                
                myMaterials = other.GetComponent<MeshRenderer>().materials;
                
                foreach(var material in myMaterials)
                {
                    other.GetComponent<MeshRenderer>();
                    material = Exposed;
                }
                */
                
                /*
                objRenderer = other.GetComponent<MeshRenderer>();
                originalColor = new Color[objRenderer.materials.Length];
        
                foreach (Material mat in objRenderer.materials)
                {
                    mat = Exposed;
                    for (i = 0; i < objRenderer.materials.Length; i++)
                    {
                        mat = Exposed;
                        originalColor[i] = Exposed;
                    }
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
