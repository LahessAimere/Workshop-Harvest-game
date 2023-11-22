using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ActivateInventory : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;

    private void Start()
    {
        _inventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Inverts the active state
            _inventory.SetActive(!_inventory.activeSelf);
        }
    }
}
