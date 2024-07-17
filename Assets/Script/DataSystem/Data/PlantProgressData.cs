using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace DataSystem
{
    [Serializable]
    public class PlantProgressData
    {
        public int Id;
        [Range(0, 1)] public float Progress;
        
        public XenoSDK.BuildingBlocks.GrabPlace.Pose Pose;

        public string PlantTypeId;
        public string PlantUID;
    }
}
