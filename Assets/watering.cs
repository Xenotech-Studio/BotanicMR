using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watering : MonoBehaviour
{
    public GameObject WaterFall;

    public GameObject WaterPipe;

    public float PipeAngle;
    

    void Update()
    {
        PipeAngle = Vector3.Angle(Vector3.down, WaterPipe.transform.right);
        bool pipeDown = PipeAngle < 80;
        if (pipeDown)
        {
            WaterDown();
            return;
        }
        WaterFall.SetActive(false);
    }

    public void WaterDown()
    {
        WaterFall.SetActive(true);
    }
}
