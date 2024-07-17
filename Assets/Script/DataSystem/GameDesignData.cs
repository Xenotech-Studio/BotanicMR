using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataSystem
{
    public class GameDesignData
    {
        public static Dictionary<int, PlantData> PlantData
        {
            get => _plantData ??= GeneratePlantData();
            set => _plantData = value;
        }
        private static Dictionary<int, PlantData> _plantData;
        public static PlantData GetPlantData(int id) => _plantData.TryGetValue(id, out var data) ? data : null;

        private static Dictionary<int, PlantData> GeneratePlantData()
        {
            var data = Resources.LoadAll<PlantData>("ScriptableObjects/PlantData");
            var dic = new Dictionary<int, PlantData>();

            foreach (var p in data)
            {
                dic.Add(p.Id, p);
            }

            return dic;
        }
    }
}
