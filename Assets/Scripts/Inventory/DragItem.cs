using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image ImageItem;
    [HideInInspector] public Transform NewPositionDrag;
    private Text _name;
    public int _level;
    private DropInventory _dropInventory;
    
    public void SetLevel(int newLevel)
    {
        _level = newLevel;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        NewPositionDrag = transform.parent;
        //Doesn't parent
        transform.SetParent(transform.root);
        //Move the transform to the end of the local transform list.
        transform.SetAsLastSibling();
        ImageItem.raycastTarget = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(NewPositionDrag);
        ImageItem.raycastTarget = true;
    }
}