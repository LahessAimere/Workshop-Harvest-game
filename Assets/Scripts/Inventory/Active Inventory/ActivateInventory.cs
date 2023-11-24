using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivateInventory : MonoBehaviour
{
    [FormerlySerializedAs("_inventory")] [SerializeField] private GameObject _scrollViewInventory;
    
    private List<ItemData> _itemInventory;
    [SerializeField] private GameObject[] _casesItem;

    public static Action<SlotItemSystem> ActionSlotItem;
    private GameObject _parentItem;

    private void Start()
    {
        _scrollViewInventory.SetActive(false);
    }
    
    private void OnEnable()
    {
        InventoryEvent.SendItemDataAction += AddItemList;
    }
    
    public void AddItemList(ItemData _item)
    {
        for (int i = 0; i < _casesItem.Length; i++)
        {
            if (_casesItem[i].transform.childCount == 0)
            {
                Instantiate(_item.ItemUiPrefab, _casesItem[i].transform); 
                break;
            }   
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Inverts the active state
            _scrollViewInventory.SetActive(!_scrollViewInventory.activeSelf);
        }
    }
}
