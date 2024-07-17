using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using UnityEngine;

public class CutablePlant : MonoBehaviour
{
    public GameObject PlantFull;
    public GameObject PlantMain;
    public GameObject PlantLeaf;

    

    public void Cutted()
    {
        PlantFull.SetActive(false);
        PlantMain.SetActive(true);
        PlantLeaf.SetActive(true);
        GameObject grabBall = Instantiate(Resources.Load("Prefabs/Grab Ball"), 
            PlantLeaf.transform.position, PlantLeaf.transform.rotation) as GameObject;
        if (grabBall is GameObject grabball) PlantLeaf.transform.parent.SetParent(grabball.transform);
        PlantLeaf.transform.position +=  0.02f * Vector3.down;
    }
}
