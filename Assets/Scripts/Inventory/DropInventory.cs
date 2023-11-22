using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class DropInventory : MonoBehaviour, IDropHandler
{
    private GameObject _dropObject;
    private DragItem _dragItem;
    private GameObject[] _inventory;
    [SerializeField] private GameObject _newItem;

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
            
            if (transform.childCount > 0 && transform.GetChild(0).CompareTag(eventData.pointerDrag.tag))
            {
                Debug.Log("drop object On Object");


                // Instantiate the new item
                _newItem = Instantiate(_newItem, transform, true);
                _newItem.transform.localScale = Vector3.one;
            
                _dragItem = transform.GetChild(0).GetComponent<DragItem>();
                _dragItem.SetLevel(_dragItem._level + 1);

                Destroy(eventData.pointerDrag);
                Destroy(_dragItem.gameObject);
            }
        }
    }
}