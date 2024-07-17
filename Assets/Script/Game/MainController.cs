using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using UnityEngine;

public class MainController : MonoBehaviour
{
    private void Awake()
    {
        RecoverPose();
    }

    public void RecordPose(XenoSDK.BuildingBlocks.GrabPlace.Pose pose)
    {
        GameProgressData.Instance.WorkbenchPose = pose;
        GameProgressData.Instance.Serialization();
    }
    
    public void RecoverPose()
    {
        if (GameProgressData.Instance.WorkbenchPose == null) return;
        
        transform.position = GameProgressData.Instance.WorkbenchPose.Position;
        transform.rotation = GameProgressData.Instance.WorkbenchPose.Rotation;
        
        gameObject.SetActive(true);
    }
}
