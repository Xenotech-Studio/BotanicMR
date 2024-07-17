using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public GameObject SoilOnShovel;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        if (collider.TryGetComponent(out SoilSource soilSource)) 
        {
            Debug.Log("Soil source: " + soilSource.name);
            if ( !SoilOnShovel.activeSelf) SoilOnShovel.SetActive(true);
        }
        if (collider.TryGetComponent(out SoilHolder soilHolder) && SoilOnShovel.activeSelf) 
        {
            SoilOnShovel.SetActive(false);
            soilHolder.SoilNum += 1;
        }
        
    }
    
}
