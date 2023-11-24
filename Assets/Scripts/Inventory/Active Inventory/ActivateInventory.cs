using System.Collections.Generic;
using UnityEngine;


public class ActivateInventory : MonoBehaviour
{
    [SerializeField] private GameObject _scrollViewInventory;
    
    private List<ItemData> _itemInventory;
    
    private GameObject _parentItem;
    
    [SerializeField] private GameObject[] _SlotsItem;
    
    private void Start()
    {
        _scrollViewInventory.SetActive(false);
    }
    
    private void OnEnable()
    {
        InventoryEvent.SendItemDataAction += AddItemList;
    }
    
    public void AddItemList(ItemData item)
    {
        for (int i = 0; i < _SlotsItem.Length; i++)
        {
            if (_SlotsItem[i].transform.childCount == 0)
            {
                Instantiate(item.ItemUiPrefab, _SlotsItem[i].transform); 
                break;
            }   
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _scrollViewInventory.SetActive(!_scrollViewInventory.activeSelf);
        }
    }
}