using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class MainController : MonoBehaviour
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

#if UNITY_EDITOR
[CustomEditor(typeof(MainController))]
public class MainControllerEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MainController mainController = (MainController) target;
        
        // draw header "tools"
        GUILayout.Space(10);
        GUILayout.Label("Actions", EditorStyles.boldLabel);
        
        if (GUILayout.Button("Restore All Plants"))
        {
            mainController.RestoreAllPlants();
        }
        
        GUILayout.Space(10);
        GUILayout.Label("Plants", EditorStyles.boldLabel);
        foreach (PlantAgent plant in MainController.Plants)
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Plant", plant, typeof(PlantAgent), false);
            GUI.enabled = true;
        }
    }
}
#endif
