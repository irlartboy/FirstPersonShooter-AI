using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    // Ref tag to detect collisions with 
    public string hitTag;
    public UnityEvent onEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == hitTag || hitTag == "")
        {
            // Run the event
            onEnter.Invoke();
        }
    }
}
