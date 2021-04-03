using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public Material Exposed;
    public ParticleSystem particle;
    public List<ParticleCollisionEvent> collisionEvents;

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
                                //Debug.Log("Infected");
                                SkinnedMeshRenderer[] newMeshRenderer = other.GetComponentsInChildren<SkinnedMeshRenderer>();
                                foreach(var m in newMeshRenderer)
                                {
                                    m.material = Exposed;
                                }
                                other.gameObject.tag = "Exposed";
                                other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                                GameObject particleObject = Instantiate(particleSystemExposed, other.transform.position, other.transform.rotation, other.transform);//prefab,pos,rot,parent
                                
                            }
                            else
                            {
                                //Debug.Log("NOT infected");
                            }
                            collidedPersonBehaviours.lastHit = Time.time;
                        }
                        
                    }
                }

            }
            else
            {
                if(!other.transform.CompareTag("Ceiling") && !other.transform.CompareTag("Floor") && !other.transform.CompareTag("Wall") && !other.transform.CompareTag("Player"))
                {
                    if(!other.transform.CompareTag("Contaminated"))
                    {
                        other.gameObject.tag = "Contaminated";
                        //other.GetComponent<MeshRenderer>().material = Exposed;
                        Material[] newMaterials = other.GetComponent<Renderer>().materials;
                        for(int j=0; j<newMaterials.Length;j++)
                        {
                            newMaterials[j] = Exposed;
                        }
                        other.GetComponent<Renderer>().materials = newMaterials;
                        
                        //ParticleSystem newParticle = other.AddComponent(typeof(ParticleSystem)) as particleSystemContaminated;
                        //other.AddComponent<GameObject>().particleSystemContaminated;
                        GameObject particleObject = Instantiate(particleSystemContaminated, other.transform.position, other.transform.rotation, other.transform);//prefab,pos,rot,parent
                        
                        //other.AddComponent<ParticleCollision>();
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
