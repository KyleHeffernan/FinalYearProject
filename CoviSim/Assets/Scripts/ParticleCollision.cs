using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Material Exposed;
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;
    
    //If collided agent has mask or vaccination these will change but if not, they do not affect stats
    private float maskPreventionChance = -.1f;

    private float vaccinePreventionChance = -.1f;

    public GameObject particleSystemContaminated;

    public GameObject particleSystemExposed;

    


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
        //Iterating through all of the collisions 
        while(i < numCollisionEvents)
        {
            // If its colliding with a healthy agent
            if(rb != null)
            {
                if(!other.transform.CompareTag("Infectious"))
                {
                    if(!other.transform.CompareTag("Exposed"))
                    {
                        //Gets the agents behaviour to see if they have mask/vaccination
                        PersonBehaviours collidedPersonBehaviours = other.GetComponent<PersonBehaviours>();
                        //2 second collision cooldown to prevent stats being irrelevant due to multiple collisions
                        if(collidedPersonBehaviours.lastHit < Time.time - 2)
                        {
                            //Affect chance based on mask/vaccination
                            if(collidedPersonBehaviours.wearingMask == true)
                            {
                                maskPreventionChance = 0.77f;
                            }

                            if(collidedPersonBehaviours.isVaccinated == true)
                            {
                                vaccinePreventionChance = 0.95f;
                            }
                            //Calculate chance of infection
                            if(Random.value > maskPreventionChance && Random.value > vaccinePreventionChance)
                            {
                                //Changing all materials to exposed for visual confirmation
                                SkinnedMeshRenderer[] newMeshRenderer = other.GetComponentsInChildren<SkinnedMeshRenderer>();
                                foreach(var m in newMeshRenderer)
                                {
                                    m.material = Exposed;
                                }
                                other.gameObject.tag = "Exposed";//For exposed counter
                                //Disables collider as they cant be exposed again, makes particles look better
                                other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                                //Adding particles to clothes
                                GameObject particleObject = Instantiate(particleSystemExposed, other.transform.position, other.transform.rotation, other.transform);//prefab,pos,rot,parent
                                
                            }
                            //Setting cooldown
                            collidedPersonBehaviours.lastHit = Time.time;
                        }
                        
                    }
                }

            }
            else
            {  
                //Not walls,roof,floor or player as its unnecassary/confusing 
                if(!other.transform.CompareTag("Ceiling") && !other.transform.CompareTag("Floor") && !other.transform.CompareTag("Wall") && !other.transform.CompareTag("Player"))
                {
                    //Making sure this object hasnt already been set
                    if(!other.transform.CompareTag("Contaminated"))
                    {
                        //Setting tag and all materials
                        other.gameObject.tag = "Contaminated";
                        Material[] newMaterials = other.GetComponent<Renderer>().materials;
                        for(int j=0; j<newMaterials.Length;j++)
                        {
                            newMaterials[j] = Exposed;
                        }
                        other.GetComponent<Renderer>().materials = newMaterials;
                        //Adding particles to represent a contaminated surface
                        GameObject particleObject = Instantiate(particleSystemContaminated, other.transform.position, other.transform.rotation, other.transform);//prefab,pos,rot,parent
                        
                        
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
