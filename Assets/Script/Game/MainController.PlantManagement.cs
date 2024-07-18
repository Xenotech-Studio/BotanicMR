using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.Events;



public partial class MainController : MonoBehaviour
{
    public static int WorldId = 0; // 0, 1, 2
    
    public List<PlantAgent> PlantPrefabs; // 不用GameDesignJson记录Plantsw那么复杂，直接在这里列出所有Plant
    public Transform PlantParent;

    public static List<PlantAgent> Plants = new List<PlantAgent>();
    
    public void RestoreAllPlants()
    {
        Debug.Log("Restoring "+GameProgressData.Instance.AllPlantProgressDataLists[WorldId].Count+" plants");
        
        foreach (PlantProgressData plantProgressData in GameProgressData.Instance.AllPlantProgressDataLists[WorldId])
        {
            GameObject plantPrefab = PlantPrefabs.Find(plantPrefab => plantPrefab.PlantId == plantProgressData.PlantTypeId).gameObject;
            
            if (plantPrefab == null)
            {
                Debug.LogError($"Plant prefab not found: {plantProgressData.PlantTypeId}");
                continue;
            }
            
            bool exist = false;
            foreach (PlantAgent _plant in Plants)
            {
                if (_plant.PlantUID == plantProgressData.PlantUID)
                {
                    _plant.Progress = plantProgressData.Progress;
                    _plant.transform.position = plantProgressData.Pose.Position;
                    _plant.transform.rotation = plantProgressData.Pose.Rotation;
                    exist = true;
                }
            }
            if (exist)
            {
                continue;
            }
            
            GameObject plantObj = Instantiate(plantPrefab, plantProgressData.Pose.Position, plantProgressData.Pose.Rotation);
            plantObj.SetActive(true);
            Transform plantT = plantObj.transform;
            plantT.parent = PlantParent;
            PlantAgent plant = plantObj.GetComponent<PlantAgent>();
            plantT.position = plantProgressData.Pose.Position;
            plantT.rotation = plantProgressData.Pose.Rotation;
            plant.Progress = plantProgressData.Progress;
            plant.PlantUID = plantProgressData.PlantUID;
            
            Plants.Add(plant);
        }
    }

    public static void RecordPlant(PlantAgent plant)
    {
        // if is a new plant with no PlantUID, generate a new PlantUID
        if (string.IsNullOrEmpty(plant.PlantUID))
        {
            plant.PlantUID = Guid.NewGuid().ToString();
        }
        
        // for each progress in current world, check whether its UID is the same as the plant's UID
        PlantProgressData plantProgressData = null;
        foreach (PlantProgressData _plantProgressData in GameProgressData.Instance.AllPlantProgressDataLists[GameProgressData.Instance.AllPlantProgressDataLists.Count - 1])
        {
            if (_plantProgressData.PlantUID == plant.PlantUID)
            {
                plantProgressData = _plantProgressData;
            }
        }
        if (plantProgressData == null)
        {
            plantProgressData = new PlantProgressData
            {
                PlantUID = plant.PlantUID,
                PlantTypeId = plant.PlantId
            };
            GameProgressData.Instance.AllPlantProgressDataLists[WorldId].Add(plantProgressData);
        }
        
        
        // record the plant's progress and pose
        plantProgressData.Progress = plant.Progress;
        plantProgressData.Pose = new XenoSDK.BuildingBlocks.GrabPlace.Pose
        {
            Position = plant.transform.position,
            Rotation = plant.transform.rotation
        };
        
        // save the progress data
        GameProgressData.Instance.Serialization();
    }
    
    public static void RemovePlant(PlantAgent plant)
    {
        PlantProgressData plantProgressData = null;
        foreach (PlantProgressData _plantProgressData in GameProgressData.Instance.AllPlantProgressDataLists[WorldId])
        {
            if (_plantProgressData.PlantUID == plant.PlantUID)
            {
                plantProgressData = _plantProgressData;
            }
        }
        if (plantProgressData != null)
        {
            GameProgressData.Instance.AllPlantProgressDataLists[WorldId].Remove(plantProgressData);
            GameProgressData.Instance.Serialization();
        }
        
        Plants.Remove(plant);
    }
    
    public GameObject SpawnNewPlant(string plantId, float progress = 0, Vector3 offset = new Vector3())
    {
        GameObject plantPrefab = PlantPrefabs.Find(plantPrefab => plantPrefab.PlantId == plantId).gameObject;
        if (plantPrefab == null)
        {
            Debug.LogError($"Plant prefab not found: {plantId}");
            return null;
        }
        
        GameObject plantObj = Instantiate(plantPrefab, Vector3.zero, Quaternion.identity);
        plantObj.SetActive(true);
        Transform plantT = plantObj.transform;
        plantT.parent = PlantParent;
        PlantAgent plant = plantObj.GetComponent<PlantAgent>();
        plantT.position = NewItemSpawnPosition.position + offset;
        plantT.rotation = Quaternion.identity;
        plant.Progress = progress;
        plant.PlantUID = Guid.NewGuid().ToString();
        
        Plants.Add(plant);
        
        return plantObj;
    }
    
    public void SpawnNewPlant10PercentGrowth(string plantId) => SpawnNewPlant(plantId, 0.1f);
    public void SpawnNewPlant30PercentGrowth(string plantId) => SpawnNewPlant(plantId, 0.3f);
    public void SpawnNewPlant50PercentGrowth(string plantId) => SpawnNewPlant(plantId, 0.5f);
    public void SpawnNewPlant70PercentGrowth(string plantId) => SpawnNewPlant(plantId, 0.7f);
}



