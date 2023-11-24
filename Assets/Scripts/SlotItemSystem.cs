using System;
using UnityEngine;

public class SlotItemSystem : MonoBehaviour
{
    public static Action<SlotItemSystem> ActionSlotItem;
    
    private void SendSlotItem()
    {
        if (ActionSlotItem != null)
        {
            ActionSlotItem.Invoke(this);
        }
    }
    
    void Start()
    {
        SendSlotItem();
    }
}