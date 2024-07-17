using System.Collections;
using System.Collections.Generic;
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

        public List<PlantProgressData> PlantProgressDataList = new List<PlantProgressData>();
    }
}
