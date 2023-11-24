using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new_"+ nameof(ScriptableObject), menuName = "ScriptableObjects/new Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] ItemType type;
    
    [SerializeField] private ItemData _itemData;
    public ItemType Type => type;
    
    [SerializeField] private GameObject[] _itemPrefab = new GameObject[Enum.GetValues(typeof(ItemType)).Length];
    public GameObject[] ItemPrefab => _itemPrefab;

    [SerializeField] private GameObject _itemUiPrefab;
    public GameObject ItemUiPrefab => _itemUiPrefab;
    
    public enum ItemType
    {
        Grass,
        WoodStick,
        Stone,
    }
}