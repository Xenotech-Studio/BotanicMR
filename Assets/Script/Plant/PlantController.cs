using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using UI;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    public PlantData Data;
    
    public Transform ModelParent;
    
    public PlantInfoPanelController InfoController;
    public PlantTutPanelController TutController;

    public int CurrentStep = 0;
    
    public void Initialization(int id)
    {
        var data = GameDesignData.GetPlantData(id);
        if (data == null) return;
        
        // Instantiate(data.Prefab, Vector3.zero, Quaternion.identity, ModelParent);
        
        Data = data;
        InfoController.SetPlantData(data);
        TutController.SetPlantData(data);
        
        InfoController.gameObject.SetActive(true);
    }

    public void StartTutorial()
    {
        InfoController.gameObject.SetActive(false);
        
        CurrentStep = 0;
        TutController.Refresh(CurrentStep);
        WorkbenchCanvasController.CallUpSubtitle(Data.Tutorial[CurrentStep].ShortDescription);
        
        TutController.gameObject.SetActive(true);
    }
    
    public void NextStep()
    {
        CurrentStep++;
        TutController.Refresh(CurrentStep);
        WorkbenchCanvasController.CallUpSubtitle(Data.Tutorial[CurrentStep].ShortDescription);
    }
}
