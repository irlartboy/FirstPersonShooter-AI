using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{
    public float weighting = 7.5f;

    protected AI owner; // Ref to owner

    protected virtual void Awake()
    {
        owner = GetComponent<AI>();
    }

    public virtual Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;

        return force;
    }

}
