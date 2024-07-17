using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    public class PlantProgressData
    {
        public int Id;
        [Range(0, 1)] public float Progress;
        public Vector3 Position;
        public Vector3 Rotation;
    }
}
