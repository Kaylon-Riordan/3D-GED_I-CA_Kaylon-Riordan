using System.Collections;
using System.Collections.Generic;
using GD.Events;
using GD.Items;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The interactable area around the slot")]
    public TargetInArea targetArea;

    //[HideInInspector]
    public ItemData slotedItem;

    public void SlotItem(ItemData data)
    {
        this.slotedItem = data;
    }
}
