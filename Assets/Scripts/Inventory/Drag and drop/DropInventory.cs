using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropInventory : MonoBehaviour, IDropHandler
{
    private GameObject _dropObject;
    private DragItem _dragItem;
    private ItemData _itemData;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (transform.childCount == 0)
            {
                _dropObject = eventData.pointerDrag;
                _dragItem = _dropObject.GetComponent<DragItem>();
                
                if (_dragItem != null)
                {
                    _dragItem.NewPositionDrag = transform;
                }
            }
            /*if (_dragItem != null && itemInSlot != null && _dragItem.DragReferenceItem != null)
            {
                if (_dragItem.DragReferenceItem.Type == itemInSlot.Type)
                {
                    Debug.Log("Les types sont identiques !");
                }
                else
                {
                    Debug.Log("Les types ne sont pas identiques.");
                }
            }*/
        }
    }


}