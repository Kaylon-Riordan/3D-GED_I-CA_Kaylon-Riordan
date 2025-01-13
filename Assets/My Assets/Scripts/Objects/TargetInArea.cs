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

    /// <summary>
    /// Set player to not be in area by default
    /// </summary>
    private void Awake()
    {
        inArea = false;
    }

    /// <summary>
    /// when an object enters the area, activate bool to true if its the player
    /// </summary>
    /// <param name="other"> other object in the collision </param>
    private void OnTriggerEnter(Collider other)
    {
        if (targetLayer.OnLayer(other.gameObject))
        {
            inArea = true;
        }
    }

    /// <summary>
    /// when an object exits the area, deactivate bool to true if its the player
    /// </summary>
    /// <param name="other"> other object in collision </param>
    private void OnTriggerExit(Collider other)
    {
        if (targetLayer.OnLayer(other.gameObject))
        {
            inArea = false;
        }
    }
}
