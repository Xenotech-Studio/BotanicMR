using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterListener : MonoBehaviour
{
    public Collider Head;
    public UnityEvent<Collider> OnEnter;
    public UnityEvent<Collider> OnExit;
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter", this);
        if (other == Head)
        {
            OnEnter.Invoke(other);
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit", this);
        if (other == Head)
        {
            OnExit.Invoke(other);
        }
    }
}
