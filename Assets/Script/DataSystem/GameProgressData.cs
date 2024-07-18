using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace DataSystem
{
    public class GameProgressData : ReadableAndWriteableData
    {
        public override string Path => System.IO.Path.Combine(Application.persistentDataPath, "GameProgressData.json");

        public static GameProgressData Instance
        {
            get => _instance ??= new GameProgressData().DeSerialization<GameProgressData>();
            set => _instance = value;
        }
        private static GameProgressData _instance;

        public XenoSDK.BuildingBlocks.GrabPlace.Pose WorkbenchPose;
        
        public List<PlantProgressData> PlantProgressDataList = new List<PlantProgressData>();
        
        public List<PlantProgressData> PlantProgressDataList2 = new List<PlantProgressData>();
        
        public List<PlantProgressData> PlantProgressDataList3 = new List<PlantProgressData>();
        
        [JsonIgnore]
        public List<List<PlantProgressData>> AllPlantProgressDataLists => new List<List<PlantProgressData>>
        {
            PlantProgressDataList, 
            PlantProgressDataList2, 
            PlantProgressDataList3
        };
        
        public int Money;
        
        public DateTime LastLoginTime;
        
        #if UNITY_EDITOR
        [UnityEditor.MenuItem("XenoSDK/Reset Game Progress Data")]
        public static void Reset()
        {
            Instance.WorkbenchPose = null;
            Instance.PlantProgressDataList.Clear();
            Instance.PlantProgressDataList2.Clear();
            Instance.PlantProgressDataList3.Clear();
            Instance.Money = 0;
            Instance.LastLoginTime = DateTime.Now;
            Instance.Serialization();
        }
        #endif
    }
}
