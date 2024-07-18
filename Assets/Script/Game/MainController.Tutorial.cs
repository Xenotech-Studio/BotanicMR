using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Versee.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class MainController : MonoBehaviour
{
    public void InteractWith(Collider obj)
    {
        if (obj.attachedRigidbody != null && obj.attachedRigidbody.transform.TryGetComponent<PlantController>(out var controller))
        {
            controller.transform.SetParent(transform.Find("Flow/Tutorial"));
            controller.transform.localPosition = new Vector3(0, 0, -0.25f);
            controller.transform.localRotation = Quaternion.Euler(0, 0, 0);
            
            transform.Find("Flow").GetComponent<VXR_Flow>().GoToID("tutorial");
        
            controller.StartTutorial();
        }
    }
}