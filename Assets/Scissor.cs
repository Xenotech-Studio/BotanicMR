using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scissor : MonoBehaviour
{
    public bool ScissorPrssed;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Transform Plant = other.transform.parent;
        if (Plant && Plant.TryGetComponent(out CutablePlant cutablePlant) && ScissorPrssed) 
        {
            cutablePlant.Cutted();
        }
    }

    public void ScissorPress()
    {
        if (ScissorPrssed == false)
        {
            ScissorPrssed = true;
            StartCoroutine(Pressing());
        }
    }

    public IEnumerator Pressing()
    {
        yield return new WaitForSeconds(0.5f);
        ScissorPrssed = false;
    }
}
