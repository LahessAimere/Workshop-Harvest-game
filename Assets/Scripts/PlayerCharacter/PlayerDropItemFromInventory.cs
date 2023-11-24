using System;
using UnityEngine;

public class PlayerDropItemFromInventory : MonoBehaviour
{
    [SerializeField] private SlotItemSystem _slotItemSystem;
    public static Action<ItemData> ActionItemData;

    private void OnEnable()
    {
        InventoryEvent.SendItemSlotItemSystem += ReceivedSlotItem;
    }

    private void ReceivedSlotItem(SlotItemSystem slotItem)
    {
        _slotItemSystem = slotItem;
        Debug.Log(_slotItemSystem);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        SciptableHolder sciptableHolder = other.GetComponent<SciptableHolder>();
        
        if (sciptableHolder != null)
        {
            Debug.Log(sciptableHolder);
            ActionItemData.Invoke(other.GetComponent<SciptableHolder>().ItemHolder);
            Destroy(other.gameObject);
        }
    }
}