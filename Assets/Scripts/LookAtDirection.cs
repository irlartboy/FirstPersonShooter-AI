using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// rotates any object at the same angle of target 
public class LookAtDirection : MonoBehaviour
{
    public Transform target; 
    private void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(target.forward);
    }
}
