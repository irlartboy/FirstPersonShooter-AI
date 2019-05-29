using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public Vector3 Velocity // propertery
    {
        protected set { velocity = value; }
        get { return velocity; }
    }

    public float maxVelocity = 5f;
    public float maxDistance = 5f;

    protected Vector3 velocity; // variable

    protected NavMeshAgent agent;
    protected SteeringBehaviour[] behaviours;

    private void Awake()
    {
        // Get naveMesh Agent
        agent = GetComponent<NavMeshAgent>();
        // get all steeeringbehaviours on AI
        behaviours = GetComponents<SteeringBehaviour>();
    }

    private void Update()
    {
        CalculateForce();
    }
    public virtual Vector3 CalculateForce()
    {
        //1. Create a result vector3
        // set force to zero
        Vector3 force = Vector3.zero;

        //2. Loop through all behaviours and get force
        foreach (var behaviour in behaviours)
        {
            // apply force to behaviour getforce
            force += behaviour.GetForce() * behaviour.weighting;

            //3. Limit the total force to maxSpeed
            // if force magnitude > maxVelocity
            if (force.magnitude > maxVelocity)
            {
                // Set force to force normailzed x maxVelocity
                force = force.normalized * maxVelocity;
                // break - exits the foreach loop
                break;
            }
        }

        //4. limit the total velocity to our max velocity if it exceeds 
        velocity += force * Time.deltaTime;
        //if velocity magnitude > max velocity
        if (velocity.magnitude > maxVelocity)
        {
            // set velocity to velocity normalized x max velocity 
            velocity = velocity.normalized * maxVelocity;
        }

        //5. sample destination for navmesh agent
        // if Velocty magnitude > 0 (velocity isnt zero)
        if (Velocity.magnitude > 0)
        {
            // the set position to current + velocity x delta time
            Vector3 pos = transform.position + velocity * Time.deltaTime;
            NavMeshHit hit;
            // if navmesh samplePosition within navmesh
            if (NavMesh.SamplePosition(pos, out hit, maxDistance, -1))
            {
                // set agent destinatino to hit position
                agent.SetDestination(hit.position);
            }

        }

        //6. Return force
        return force;
    }

}
