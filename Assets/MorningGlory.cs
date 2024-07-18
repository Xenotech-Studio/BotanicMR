using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MorningGlory : MonoBehaviour
{

    public GameObject FullPlant;
    public GameObject Seed;
    public UnityEvent PlaceSeed;

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SoilHolder soilHolder) && soilHolder.SoilFull)
        {
            PlaceSeed.Invoke();
        }

        if (other.TryGetComponent(out woodenGrid woodenGrid))
        {
            Seed.SetActive(false);
            FullPlant.SetActive(true);
        }
    }
}
