using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using XenoSDK.BuildingBlocks.GrabPlace;

#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class MainController : MonoBehaviour
{
    public GameObject GrabPlacerPrefab;
    
    public void SpawnByGameObject(GameObject gameObject)
    {
        Debug.Log("Spawning " + gameObject.name);
        
        Vector3 relativePosition = new Vector3();
        if (gameObject.TryGetComponent(out SpawnableObject spawnableObject))
        {
            relativePosition = - spawnableObject.SpawingPivot.localPosition;
        }
        
        GameObject spawnedObject = null;
        
        // Plant
        if (gameObject.TryGetComponent(out PlantAgent plantAgent))
        {
            try
            {
                spawnedObject = SpawnNewPlant(plantAgent.PlantId, 0.1f, relativePosition);
            }
            catch
            { }
        }
        // Furniture
        else
        {
            spawnedObject = Instantiate(gameObject, NewItemSpawnPosition.position + relativePosition,
                NewItemSpawnPosition.rotation);
            spawnedObject.SetActive(true);
        }
        
        if (spawnedObject == null)
        {
            Debug.LogError("Failed to spawn " + gameObject.name);
            return;
        }
        
        // if it has a grabPlaceable component,
        // spawn a GrabPlacer for it
        if (spawnedObject.TryGetComponent(out GrabPlaceable grabPlaceable))
        {
            Debug.Log("Spawning " + gameObject.name + " with GrabPlacer");
            
            // TODO 暂时不支持grabPlaceable的旋转
            GameObject grabPlacer = Instantiate(
                GrabPlacerPrefab, NewItemSpawnPosition.position + relativePosition - grabPlaceable.GrabRelativePose.Position,
                NewItemSpawnPosition.rotation);
            grabPlacer.SetActive(true);
            grabPlacer.GetComponent<GrabPlacer>().WhatToPlace = grabPlaceable;
            grabPlacer.GetComponent<GrabPlacer>().Initialize();
            return;
        }
        
    }
}
