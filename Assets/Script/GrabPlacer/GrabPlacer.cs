using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XenoSDK.BuildingBlocks.GrabPlace
{
    
    public class GrabPlacer : MonoBehaviour
    {
        public GrabPlaceable WhatToPlace;

        [Header("Dont-change Parameters")] 
        public VXR_Interactable GrabHandle;
        public SmoothFollowTransform PivotTransform; // Smooth Follow 直接跟随握把的物体
        public Transform ResultTransform; // Pivot 的子物体，相对于pivot有位移，其位置等于最终放置位置

        public void Initialize()
        {
            ResultTransform.localPosition = WhatToPlace.GrabRelativePose.Position;
            ResultTransform.localRotation = WhatToPlace.GrabRelativePose.Rotation;
        }

        public void Confirm()
        {
            WhatToPlace.ConfirmPlace();
        }

        public void StartGrab()
        {
            PivotTransform.RecordAndKeepRelativeRotation();
            PivotTransform.enabled = true;
        }
        
        public void EndGrab()
        {
            PivotTransform.enabled = false;
        }
        
        public void Update()
        {
            WhatToPlace.transform.position = ResultTransform.position;
            WhatToPlace.transform.rotation = ResultTransform.rotation;
        }
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(GrabPlacer))]
    public class GrabPlacerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GrabPlacer grabPlacer = (GrabPlacer) target;
            
            // draw header "tools"
            GUILayout.Space(10);
            GUILayout.Label("Inspector for Placeable", EditorStyles.boldLabel);
            
            if (grabPlacer.WhatToPlace == null)
            {
                GUILayout.Label("WhatToPlace is null", EditorStyles.boldLabel);
                return;
            }
            else
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Space(5);
                GUILayout.BeginVertical();
                GUILayout.Space(5);
                GrabPlacableEditor.DrawEditor(grabPlacer.WhatToPlace, grabPlacer);
                GUILayout.Space(5);
                GUILayout.EndVertical();
                GUILayout.Space(5);
                GUILayout.EndHorizontal();
            }

            // draw header
            GUILayout.Space(10);
            GUILayout.Label("Actions", EditorStyles.boldLabel);
            
            if (GUILayout.Button("Update"))
            {
                grabPlacer.Update();
            }
            
            if (GUILayout.Button("Confirm"))
            {
                grabPlacer.Confirm();
            }
            
            // Horizontal
            
            GUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Start Grab"))
            {
                grabPlacer.StartGrab();
            }
            
            if (GUILayout.Button("End Grab"))
            {
                grabPlacer.EndGrab();
            }
            
            GUILayout.EndHorizontal();
        }
    }
    #endif
}
