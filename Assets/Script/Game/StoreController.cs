using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Pose = XenoSDK.BuildingBlocks.GrabPlace.Pose;

public class StoreController : MonoBehaviour
{
    public List<Transform> Items = new List<Transform>();
    public Transform ItemsParent;
    
    private List<Pose> _poses = new List<Pose>();
        
    public List<Transform> CorresponingBuyResult = new List<Transform>();
    
    public UnityEvent OnItemPutToBuyArea;
    
    public UnityEvent<GameObject> OnBuyObject;

    private void OnEnable()
    {
        foreach (var item in Items)
        {
            _poses.Add(new Pose()
            {
                Position = item.localPosition,
                Rotation = item.localRotation
            });
        }
    }


    public void ProcessTriggerEnter(Collider other)
    {
        foreach (var item in Items)
        {
            if (other.attachedRigidbody.gameObject == item.gameObject)
            {
                Debug.Log("Putting " +item.gameObject.name+ " to buy area");
                OnItemPutToBuyArea?.Invoke();
                
                // Find the corresponding buy result
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i] == item)
                    {
                        other.attachedRigidbody.transform.parent = ItemsParent;
                        other.attachedRigidbody.transform.localPosition = _poses[i].Position;
                        other.attachedRigidbody.transform.localRotation = _poses[i].Rotation;
                        OnBuyObject?.Invoke(CorresponingBuyResult[i].gameObject);
                    }
                }
            }
        }
    }
}
