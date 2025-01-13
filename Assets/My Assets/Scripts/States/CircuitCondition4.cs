using System.Collections.Generic;
using GD.Items;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that circuit 4 is correctly completed.
    /// </summary>
    [CreateAssetMenu(fileName = "CircuitCondition4", menuName = "GD/Conditions/Single/C4", order = 2)]
    public class CircuitCondition4 : ConditionBase
    {
        [FoldoutGroup("Slots", expanded: true)]
        [SerializeField]
        private Transform slot1;
        [FoldoutGroup("Slots")]
        [SerializeField]
        private Transform slot2;
        [FoldoutGroup("Slots")]
        [SerializeField]
        private Transform slot3;
        [FoldoutGroup("Slots")]
        [SerializeField]
        private Transform slot4;
        [FoldoutGroup("Slots")]
        [SerializeField]
        private Transform slot5;

        [FoldoutGroup("Data", expanded: true)]
        [SerializeField]
        private ItemData data1;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data2;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data3;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data4;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data5;

        [FoldoutGroup("Lights", expanded: true)]
        [SerializeField]
        private Light light1;
        [FoldoutGroup("Lights")]
        [SerializeField]
        private Light light2;
        [FoldoutGroup("Lights")]
        [SerializeField]
        private Light light3;
        [FoldoutGroup("Lights")]
        [SerializeField]
        private Light light4;
        [FoldoutGroup("Lights")]
        [SerializeField]
        private Light light5;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            if (evaluate(slot1, slot2, slot3, slot4, slot5, light5))
            {
                return true;
            }
            else
            {
                light1.intensity = 0f;
                light2.intensity = 0f;
                light3.intensity = 0f;
                light4.intensity = 0f;
                light5.intensity = 0f;
                return false;
            }
        }

        private bool evaluate(Transform s1, Transform s2, Transform s3, Transform s4, Transform s5, Light l)
        {
            if (s1.GetComponent<Slot>().slotedItem == data1 
                && ((s2.GetComponent<Slot>().slotedItem == data2 && s3.GetComponent<Slot>().slotedItem == data3 && s4.GetComponent<Slot>().slotedItem == data4)
                || (s2.GetComponent<Slot>().slotedItem == data2 && s3.GetComponent<Slot>().slotedItem == data4 && s4.GetComponent<Slot>().slotedItem == data3)
                || (s2.GetComponent<Slot>().slotedItem == data3 && s3.GetComponent<Slot>().slotedItem == data2 && s4.GetComponent<Slot>().slotedItem == data4)
                || (s2.GetComponent<Slot>().slotedItem == data3 && s3.GetComponent<Slot>().slotedItem == data4 && s4.GetComponent<Slot>().slotedItem == data2)
                || (s2.GetComponent<Slot>().slotedItem == data4 && s3.GetComponent<Slot>().slotedItem == data2 && s4.GetComponent<Slot>().slotedItem == data3)
                || (s2.GetComponent<Slot>().slotedItem == data4 && s3.GetComponent<Slot>().slotedItem == data3 && s4.GetComponent<Slot>().slotedItem == data2))
                && s5.GetComponent<Slot>().slotedItem == data5)
            {
                l.intensity = 500f;
                return true;
            }
            return false;
        }
    }
}