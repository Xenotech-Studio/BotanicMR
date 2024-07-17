using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class MainController : MonoBehaviour
{
    public UnityEvent Initialization;
    public UnityEvent FirstTimeEnterGame;
    
    private void Awake()
    {
        Initialization?.Invoke();
        
        RecoverPose();
    }

    private void OnApplicationQuit()
    {
        GameProgressData.Instance.LastLoginTime = DateTime.Now;
        GameProgressData.Instance.Serialization();
    }

    public void RecordPose(XenoSDK.BuildingBlocks.GrabPlace.Pose pose)
    {
        GameProgressData.Instance.WorkbenchPose = pose;
        GameProgressData.Instance.Serialization();
    }
    
    public void RecoverPose()
    {
        if (GameProgressData.Instance.WorkbenchPose == null)
        {
            FirstTimeEnterGame?.Invoke();
            return;
        }
        
        transform.position = GameProgressData.Instance.WorkbenchPose.Position;
        transform.rotation = GameProgressData.Instance.WorkbenchPose.Rotation;
        
        transform.Find("Workbench").gameObject.SetActive(true);
    }
}
