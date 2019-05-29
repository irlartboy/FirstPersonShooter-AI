using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
    public Transform target;
    public float stoppingDistance;

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        // 1. Check if we have a valid target
        // if target is null
        // return force (zero)
        if (target)
        {
            // 2.  Get direction we want to go
            // set desiredForce to target
            Vector3 desiredForce = target.position - transform.position;

            // 3. Apply weighting to desired force
            // If desiredForce distance is greater than stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                // set desired for to restricted desircerdForce 9using weighting
                desiredForce = desiredForce.normalized * weighting;
                //Set force to desiredForce - velocity
                force = desiredForce - owner.Velocity;
            }

        }

        return force;
    }
}
