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

    public void setModel(GameObject newModel)
    {
        if (itemModel != null)
        {
            Destroy(itemModel);
        }
        itemModel = Instantiate(newModel, transform.position, transform.rotation);
    }
}
