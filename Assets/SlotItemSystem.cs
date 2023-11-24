using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotItemSystem : MonoBehaviour
{
    private List<ItemData> _itemInventory;
    [SerializeField] private GameObject[] _casesItem;

    public static Action<SlotItemSystem> ActionSlotItem;
    private GameObject _parentItem;

    private void SendSlotItem()
    {
        ActionSlotItem.Invoke(this);
    }
    
    void Start()
    {
        SendSlotItem();
    }
}
