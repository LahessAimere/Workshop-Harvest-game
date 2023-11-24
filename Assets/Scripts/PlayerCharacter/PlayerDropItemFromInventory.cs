using System;
using UnityEngine;

public class PlayerDropItemFromInventory : MonoBehaviour
{
    [SerializeField] private SlotItemSystem _slotItemSystem;

    public static Action<ItemData> _actionItemData;

    private void OnEnable()
    {
        InventoryEvent.SendItemSlotItemSystem += ReceivedSlotItem;
    }

    private void ReceivedSlotItem(SlotItemSystem _slotItem)
    {
        _slotItemSystem = _slotItem;
    }

    private void OnTriggerEnter(Collider other)
    {
            _actionItemData.Invoke(other.GetComponent<SciptableHolder>()._itemData);
            Destroy(other.gameObject);
    }
}