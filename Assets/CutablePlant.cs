using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CutablePlant : MonoBehaviour
{
    public GameObject PlantFull;
    public GameObject PlantMain;
    public GameObject PlantLeaf;
    public UnityEvent SetStep;
    

    public void Cutted()
    {
        PlantFull.SetActive(false);
        PlantMain.SetActive(true);
        PlantLeaf.SetActive(true);
        GameObject grabBall = Instantiate(Resources.Load("Prefabs/Grab Ball"), 
            PlantLeaf.transform.position, PlantLeaf.transform.rotation) as GameObject;
        if (grabBall is GameObject grabball) PlantLeaf.transform.parent.SetParent(grabball.transform);


        grabBall.GetComponentInChildren<SphereCollider>().GetComponent<MeshRenderer>().enabled = false;
        PlantLeaf.transform.position +=  0.02f * Vector3.down;
        SetStep.Invoke();
    }
}
