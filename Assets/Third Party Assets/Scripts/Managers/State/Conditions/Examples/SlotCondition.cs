using GD.Items;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that a slot contains the correct item data.
    /// </summary>
    [CreateAssetMenu(fileName = "SlotCondition", menuName = "GD/Conditions/Single/Slot", order = 2)]
    public class SlotCondition : ConditionBase
    {
        [Tooltip("The slot we are assessing the data of.")]
        [SerializeField]
        private Transform slot;

        [Tooltip("The data the slot is required to have.")]
        [SerializeField]
        private ItemData data;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            Debug.Log(slot.GetComponent<Slot>().slotedItem);
            if (slot.GetComponent<Slot>().slotedItem == null) return false;
            Debug.Log(slot.GetComponent<Slot>().slotedItem == data);
            return slot.GetComponent<Slot>().slotedItem == data;
        }
    }
}