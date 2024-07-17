using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowableLeaf : MonoBehaviour
{
    public GameObject Root;
    public GameObject FullPlant;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WaterBucket waterBucket))
        {
            Root.SetActive(true);
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
