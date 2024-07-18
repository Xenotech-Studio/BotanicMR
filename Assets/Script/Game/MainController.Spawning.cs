using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

public partial class MainController : MonoBehaviour
{
    public void SpawnByGameObject(GameObject gameObject)
    {
        
        Vector3 relativePosition = new Vector3();
        if (gameObject.TryGetComponent(out SpawnableObject spawnableObject))
        {
            relativePosition = - spawnableObject.SpawingPivot.localPosition;
        }

        if (gameObject.TryGetComponent(out PlantAgent plantAgent))
        {
            try
            {
                SpawnNewPlant(plantAgent.PlantId, 0.1f, relativePosition);
            }
            catch
            { }
            return;
        }
            



        GameObject obj = Instantiate(gameObject, NewItemSpawnPosition.position + relativePosition,
            NewItemSpawnPosition.rotation);
        obj.SetActive(true);
        
    }
}
