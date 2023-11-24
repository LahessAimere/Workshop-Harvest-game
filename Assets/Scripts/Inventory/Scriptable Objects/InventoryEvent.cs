using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new_" + nameof(ScriptableObject), menuName = "Event/Scriptable Event")]
public class InventoryEvent : ScriptableObject
{
    public static Action<SlotItemSystem> SendItemSlotItemSystem;
    public static Action<ItemData> SendItemDataAction;


    private void OnEnable()
    {
        SlotItemSystem.ActionSlotItem += SendAction;
        PlayerDropItemFromInventory._actionItemData += SendItemData;
    }

    private void SendItemData(ItemData _itemData)
    {
        SendItemDataAction.Invoke(_itemData);
    }

    private void SendAction(SlotItemSystem _slotItemSystem)
    {
        SendItemSlotItemSystem.Invoke(_slotItemSystem);
    }
}