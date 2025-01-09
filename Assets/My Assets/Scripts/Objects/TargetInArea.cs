using System.Collections;
using System.Collections.Generic;
using GD.Items;
using UnityEngine;
using UnityEngine.Windows;

public class TargetInArea : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The layer that the target is on")]
    private LayerMask targetLayer;

    public bool inArea;

    private void Awake()
    {
        inArea = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetLayer.OnLayer(other.gameObject))
        {
            inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetLayer.OnLayer(other.gameObject))
        {
            inArea = false;
        }
    }
}
