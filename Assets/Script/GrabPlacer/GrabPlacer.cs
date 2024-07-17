using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace XenoSDK.BuildingBlocks.GrabPlace
{
    public class Pose
    {
        public Vector3 Position;
        public Quaternion Rotation;
    }
    
    public class GrabPlacer : MonoBehaviour
    {
        public GrabPlacable WhatToPlace;

        [Header("Dont-change Parameters")] 
        public VXR_Interactable GrabHandle;
        public Transform PivotTransform; // Smooth Follow 直接跟随握把的物体
        public Transform ResultTransform; // Pivot 的子物体，相对于pivot有位移，其位置等于最终放置位置

        public UnityEvent<Pose> OnConfirm;

        public void Initialize()
        {
            ResultTransform.localPosition = WhatToPlace.GrabRelativePose;
        }

        public void Confirm()
        {
            OnConfirm?.Invoke(new Pose()
            {
                Position = ResultTransform.position, 
                Rotation = ResultTransform.rotation
            });
        }
    }
}
