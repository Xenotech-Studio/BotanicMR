using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GrowableLeaf : MonoBehaviour
{
    public GameObject Root;
    public GameObject FullPlant;
    public UnityEvent SetStep1;

    public void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WaterBucket waterBucket))
        {
            Root.SetActive(true);
            SetStep1.Invoke();
        }

        if (other.TryGetComponent(out SoilHolder soilHolder) && soilHolder.SoilFull)
        {
            if (Root.activeSelf)
            {
                FullPlant.SetActive(true);
                Root.SetActive(false);
            }
        }
    }
}
