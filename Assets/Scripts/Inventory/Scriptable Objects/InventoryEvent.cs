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
        PlayerDropItemFromInventory.ActionItemData += SendItemData;
    }

    private void SendItemData(ItemData item)
    {
        SendItemDataAction.Invoke(item);
    }

    private void SendAction(SlotItemSystem slotItemSystem)
    {
        SendItemSlotItemSystem.Invoke(slotItemSystem);
    }
}