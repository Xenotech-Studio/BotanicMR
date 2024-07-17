using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DataSystem
{
    [CreateAssetMenu(fileName = "PlantData", menuName = "ScriptableObjects/Plant Data")]
    public class PlantData : ScriptableObject
    {
        public int Id;
        public string Name;
        public string BotanicalName;
        [Multiline] public string Description;

        public GameObject Prefab;

        [Range(0, 1)] public float SunlightDegree;
        public string SunlightDescription;
        
        [Range(0, 1)] public float WateringDegree;
        public string WateringDescription;
        
        [Range(0, 1)] public float TemperatureDegree;
        public string TemperatureDescription;
    }
}
