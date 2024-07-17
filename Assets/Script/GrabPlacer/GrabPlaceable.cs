
using System;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XenoSDK.BuildingBlocks.GrabPlace
{
    public class GrabPlaceable : MonoBehaviour
    {
        [SerializeField]
        public Pose GrabRelativePose = new Pose()
        {
            Position = new Vector3(0, 0.061f, 0.082f),
            Rotation = Quaternion.Euler(0, 0, 0)
        };
        
        public Pose CurrentPose => new Pose() { Position = transform.position, Rotation = transform.rotation };
        
        public UnityEvent<Pose> OnPlaced;
        
        public void ConfirmPlace()
        {
            OnPlaced?.Invoke(CurrentPose);
        }
    }
    
    #if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(GrabPlaceable))]
    public class GrabPlacableEditor : UnityEditor.Editor
    {
        public GrabPlacer grabPlacer;

        private void Awake()
        {
            foreach (GrabPlacer placer in FindObjectsOfType<GrabPlacer>())
            {
                if (placer.WhatToPlace == (GrabPlaceable) target)
                {
                    grabPlacer = placer;
                    break;
                }
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            // draw reference to current script
            //GUI.enabled = false;
            //EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((GrabPlaceable) target), typeof(GrabPlaceable), false);
            //GUI.enabled = true;
            
            GrabPlaceable grabPlaceable = (GrabPlaceable) target;
            DrawEditor(grabPlaceable, grabPlacer, isNative:true);
        }
        
        public static void DrawEditor(GrabPlaceable grabPlaceable, GrabPlacer grabPlacer = null, bool isNative = false) {
            // draw header "tools"

            if (!isNative)
            {
                GUILayout.Label("Grab Relative Pose", EditorStyles.boldLabel);

                EditorGUI.BeginChangeCheck();
                var pos = EditorGUILayout.Vector3Field("Position", grabPlaceable.GrabRelativePose.Position);
                var rot = EditorGUILayout.Vector3Field("Rotation", grabPlaceable.GrabRelativePose.Rotation.eulerAngles);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(grabPlaceable, "Change Grab Relative Pose");
                    grabPlaceable.GrabRelativePose.Position = pos;
                    grabPlaceable.GrabRelativePose.Rotation = Quaternion.Euler(rot);
                    // dirty
                    EditorUtility.SetDirty(grabPlaceable);
                }
            }

            if (grabPlacer != null)
            {

                GUILayout.Space(10);
                GUILayout.Label("Update Relative Pose Tool", EditorStyles.boldLabel);
                
                GUI.enabled = false;
                EditorGUILayout.ObjectField("Grab Placer", grabPlacer, typeof(GrabPlacer), false);
                GUI.enabled = true;

                if (GUILayout.Button("Update to Current"))
                {
                    grabPlacer.ResultTransform.position = grabPlacer.WhatToPlace.transform.position;
                    grabPlacer.ResultTransform.rotation = grabPlacer.WhatToPlace.transform.rotation;

                    Vector3 newRelativePose = grabPlacer.ResultTransform.localPosition;
                    Quaternion newRelativeRotation = grabPlacer.ResultTransform.localRotation;

                    grabPlacer.WhatToPlace.GrabRelativePose.Position = newRelativePose;
                    grabPlacer.WhatToPlace.GrabRelativePose.Rotation = newRelativeRotation;

                    EditorUtility.SetDirty(grabPlacer.WhatToPlace);
                }
            }

        }
    }
    #endif
}
