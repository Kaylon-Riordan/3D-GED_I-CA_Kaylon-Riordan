using System.Collections;
using System.Collections.Generic;
using GD.Events;
using GD.Items;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The interactable area around the slot")]
    public TargetInArea targetArea;

    [HideInInspector]
    public ItemData slotedItem;

    private GameObject itemModel;

    public void SlotItem(ItemData data)
    {
        this.slotedItem = data;
    }

    /// <summary>
    /// Display the model of the attatched item above the slot
    /// </summary>
    /// <param name="newModel"> model to be displayed </param>
    public void setModel(GameObject newModel)
    {
        // destroy the model if theres already one attatched
        if (itemModel != null)
        {
            Destroy(itemModel);
        }
        // add the model in at the slots position and rotation
        itemModel = Instantiate(newModel, transform.position, transform.rotation);
    }
}
