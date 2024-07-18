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

    public void Initialization()
    {
        if (Data == null) return;
        
        InfoController.SetPlantData(Data);
        TutController.SetPlantData(Data);
        
        InfoController.gameObject.SetActive(true);
    }

    public void StartTutorial()
    {
        WorkbenchCanvasController.HideSubtitle();
        InfoController.gameObject.SetActive(false);
        
        CurrentStep = 0;
        if (Data.Tutorial == null || Data.Tutorial.Count == 0) return;

        TutController.PlantData = Data;
        TutController.Refresh(CurrentStep);
        WorkbenchCanvasController.CallUpSubtitle(Data.Tutorial[CurrentStep].ShortDescription);
        
        TutController.gameObject.SetActive(true);
    }
    
    public void NextStep()
    {
        WorkbenchCanvasController.HideSubtitle();
        
        CurrentStep++;
        TutController.Refresh(CurrentStep);
        WorkbenchCanvasController.CallUpSubtitle(Data.Tutorial[CurrentStep].ShortDescription);
    }

    public void SetStepTo(int step)
    {
        WorkbenchCanvasController.HideSubtitle();
        InfoController.gameObject.SetActive(false);

        CurrentStep = step;
        if (Data.Tutorial == null || Data.Tutorial.Count <= step) return;
        
        TutController.Refresh(CurrentStep);
        WorkbenchCanvasController.CallUpSubtitle(Data.Tutorial[CurrentStep].ShortDescription);
        
        TutController.gameObject.SetActive(true);
    }

    public void EndTutorial()
    {
        WorkbenchCanvasController.HideSubtitle();
        TutController.gameObject.SetActive(false);
    }
        
}
