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
                    SkinnedMeshRenderer[] newMeshRenderer = other.GetComponentsInChildren<SkinnedMeshRenderer>();
                    foreach(var m in newMeshRenderer)
                    {
                        m.material = Exposed;
                    }
                    //other.GetComponentsInChildren<SkinnedMeshRenderer>().material = Exposed;
                    other.gameObject.tag = "Exposed";
                }

            }
            else
            {
                if(!other.transform.CompareTag("Ceiling") && !other.transform.CompareTag("Floor") && !other.transform.CompareTag("Wall"))
                {
                    //other.GetComponent<MeshRenderer>().material = Exposed;
                    Material[] newMaterials = other.GetComponent<Renderer>().materials;
                    for(int j=0; j<newMaterials.Length;j++)
                    {
                        newMaterials[j] = Exposed;
                    }
                    other.GetComponent<Renderer>().materials = newMaterials;
                }


                

                //ok
                //other.GetComponentsInChildren<MeshRenderer>().material = Exposed;

                
                
            }
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
