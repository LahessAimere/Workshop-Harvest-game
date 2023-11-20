using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 camPosition;

    private void Start()
    {
        camPosition = new Vector3(-0.2950623f, 14.67f, 0.6499981f);
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + camPosition;
    }
}
