using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoreController : MonoBehaviour
{
    public List<Transform> Items = new List<Transform>();

    public List<Transform> CorresponingBuyResult = new List<Transform>();
    
    public UnityEvent OnItemPutToBuyArea;
    
    public UnityEvent<GameObject> OnBuyObject;
    

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
                        OnBuyObject?.Invoke(CorresponingBuyResult[i].gameObject);
                    }
                }
            }
        }
    }
}
