using System.Collections;
using System.Collections.Generic;
using DataSystem;
using UI;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public PlantData Data;
    public Transform ModelParent;
    public PlantInfoPanelController Controller;

    public void Initialization(int id)
    {
        var data = GameDesignData.GetPlantData(id);
        if (data == null) return;
        
        Instantiate(data.Prefab, Vector3.zero, Quaternion.identity, ModelParent);
        
        Data = data;
        Controller.SetPlantData(data);
    }
}
