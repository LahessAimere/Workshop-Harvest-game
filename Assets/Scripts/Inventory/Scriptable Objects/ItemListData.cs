using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new_" + nameof(ScriptableObject), menuName = "ScriptableObjects/new ItemList")]
public class ItemListData : ScriptableObject
{
    [SerializeField] private List<ItemData> _itemDataList;
    public List<ItemData> ItemDataList => _itemDataList;
}