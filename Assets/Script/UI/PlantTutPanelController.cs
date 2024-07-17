using System;
using System.Collections;
using System.Collections.Generic;
using DataSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlantTutPanelController : MonoBehaviour
    {
        public PlantData PlantData;

        private TMP_Text _content;

        private void Awake()
        {
            _content = transform.Find("Panel/Content/Content").GetComponent<TMP_Text>();
        }

        public void Refresh(int step)
        {
            if (PlantData == null) return;
            
            _content = transform.Find("Panel/Content/Content").GetComponent<TMP_Text>();
            
            _content.text = PlantData.Tutorial[step].Description;
        }
        
        public void SetPlantData(PlantData plantData)
        {
            PlantData = plantData;
            
            _content = transform.Find("Panel/Content/Content").GetComponent<TMP_Text>();
        }
    }
}
