using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlantInfoPanelController : MonoBehaviour
    {
        public PlantData PlantData;

        private TMP_Text _name;
        private TMP_Text _botanicalName;
        private TMP_Text _description;
        
        private Slider _sunlightDegree;
        private TMP_Text _sunlightDescription;
        
        private Slider _wateringDegree;
        private TMP_Text _wateringDescription;
        
        private Slider _temperatureDegree;
        private TMP_Text _temperatureDescription;

        private void Awake()
        {
            _name = transform.Find("Panel/Content/Name").GetComponent<TMP_Text>();
            _botanicalName = transform.Find("Panel/Content/BotanicalName").GetComponent<TMP_Text>();
            _description = transform.Find("Panel/Content/Description").GetComponent<TMP_Text>();
            
            _sunlightDegree = transform.Find("Panel/Content/Ratings/Sunlight/Slider").GetComponent<Slider>();
            _sunlightDescription = transform.Find("Panel/Content/Ratings/Sunlight/Slider/Description").GetComponent<TMP_Text>();
            
            _wateringDegree = transform.Find("Panel/Content/Ratings/Watering/Slider").GetComponent<Slider>();
            _wateringDescription = transform.Find("Panel/Content/Ratings/Watering/Slider/Description").GetComponent<TMP_Text>();
            
            _temperatureDegree = transform.Find("Panel/Content/Ratings/Temperature/Slider").GetComponent<Slider>();
            _temperatureDescription = transform.Find("Panel/Content/Ratings/Temperature/Slider/Description").GetComponent<TMP_Text>();
            
            Refresh();
        }

        public void Refresh()
        {
            if (PlantData == null) return;
            
            _name.SetText(PlantData.Name);
            _description.SetText(PlantData.Description);
            _botanicalName.SetText(PlantData.BotanicalName);
            
            _sunlightDegree.SetValueWithoutNotify(PlantData.SunlightDegree);
            _sunlightDescription.SetText(PlantData.SunlightDescription);
            
            _wateringDegree.SetValueWithoutNotify(PlantData.WateringDegree);
            _wateringDescription.SetText(PlantData.WateringDescription);
            
            _temperatureDegree.SetValueWithoutNotify(PlantData.TemperatureDegree);
            _temperatureDescription.SetText(PlantData.TemperatureDescription);
        }
        
        public void SetPlantData(PlantData plantData)
        {
            PlantData = plantData;
            Refresh();
        }
    }
}
