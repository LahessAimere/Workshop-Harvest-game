using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image _imageItem;
    [HideInInspector] public Transform NewPositionDrag;
    
    private DropInventory _dropInventory;

    private ItemData dragReferenceItem;
    public ItemData DragReferenceItem => dragReferenceItem;
    
    
    private void Start()
    {
        _imageItem = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        NewPositionDrag = transform.parent;
        //Doesn't parent
        transform.SetParent(transform.root);
        //Move the transform to the end of the local transform list.
        transform.SetAsLastSibling();
        _imageItem.raycastTarget = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        ItemData referenceItem = gameObject.GetComponent<ItemData>();
        dragReferenceItem = referenceItem;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(NewPositionDrag);
        _imageItem.raycastTarget = true;
    }
}