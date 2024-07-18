using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEnterForwarder : MonoBehaviour
{
    public UnityEvent<Collider> OnEnter;
    public UnityEvent<Collider> OnExit;
    
    public void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke(other);
    }
    
    public void OnTriggerExit(Collider other)
    {
        OnExit.Invoke(other);
    }
}
