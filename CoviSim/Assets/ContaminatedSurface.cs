using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContaminatedSurface : MonoBehaviour
{
    public Material Exposed;
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;

    private float maskPreventionChance = -.1f;

    private float vaccinePreventionChance = -.1f;


    


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
        //Debug.Log("name: " + other.transform.name + ", tag: " + other.transform.tag);

        while(i < numCollisionEvents)
        {
            //Debug.Log(i + "," + numCollisionEvents);

            if(rb != null)
            {
                if(!other.transform.CompareTag("Infectious"))
                {
                    if(!other.transform.CompareTag("Exposed"))
                    {

                        PersonBehaviours collidedPersonBehaviours = other.GetComponent<PersonBehaviours>();

                        if(collidedPersonBehaviours.lastHit < Time.time - 2)
                        {
                            if(collidedPersonBehaviours.wearingMask == true)
                            {
                                maskPreventionChance = 0.77f;
                            }

                            if(collidedPersonBehaviours.isVaccinated == true)
                            {
                                vaccinePreventionChance = 0.95f;
                            }

                            if(Random.value > maskPreventionChance && Random.value > vaccinePreventionChance)
                            {
                                Debug.Log("Infected from surface");
                                SkinnedMeshRenderer[] newMeshRenderer = other.GetComponentsInChildren<SkinnedMeshRenderer>();
                                foreach(var m in newMeshRenderer)
                                {
                                    m.material = Exposed;
                                }
                                other.gameObject.tag = "Exposed";
                            }
                            else
                            {
                                Debug.Log("NOT infected from surface");
                            }
                            collidedPersonBehaviours.lastHit = Time.time;
                        }
                        
                    }
                }

            }
            i++;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
