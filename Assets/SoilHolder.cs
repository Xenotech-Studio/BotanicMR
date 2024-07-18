using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoilHolder : MonoBehaviour
{
    public GameObject Soil1;
    public GameObject Soil2;
    public GameObject Soil3;
    public int SoilNum;
    public bool SoilFull;
    public UnityEvent SoilFulled;

    // Update is called once per frame
    void Update()
    {
        if (SoilNum >=1) Soil1.SetActive(true);
        if (SoilNum >= 2) Soil2.SetActive(true);
        if (SoilNum >= 3)
        {
            Soil3.SetActive(true);
            SoilFull = true;
            SoilFulled.Invoke();
        }
    }
}
