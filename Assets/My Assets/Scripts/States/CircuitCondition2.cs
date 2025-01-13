using System.Collections.Generic;
using GD.Items;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that circuit 2 is correctly completed.
    /// </summary>
    [CreateAssetMenu(fileName = "CircuitCondition2", menuName = "GD/Conditions/Single/C2", order = 2)]
    public class CircuitCondition2 : ConditionBase
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
        [FoldoutGroup("Slots")]
        [SerializeField]
        private Transform slot6;

        [FoldoutGroup("Data", expanded: true)]
        [SerializeField]
        private ItemData data1;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data2;
        [FoldoutGroup("Data")]
        [SerializeField]
        private ItemData data3;

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
        [FoldoutGroup("Lights")]
        [SerializeField]
        private Light light6;

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            if (evaluate(slot1, slot2, slot3, slot4, slot5, slot6, light4, light5, light6))
            {
                return true;
            }
            else if (evaluate(slot2, slot3, slot4, slot5, slot6, slot1, light5, light6, light1))
            {
                return true;
            }
            else if (evaluate(slot3, slot4, slot5, slot6, slot1, slot2, light6, light1, light2))
            {
                return true;
            }
            else if (evaluate(slot4, slot5, slot6, slot1, slot2, slot3, light1, light2, light3))
            {
                return true;
            }
            else if (evaluate(slot5, slot6, slot1, slot2, slot3, slot4, light2, light3, light4))
            {
                return true;
            }
            else if (evaluate(slot6, slot1, slot2, slot3, slot4, slot5, light3, light4, light5))
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
                light6.intensity = 0f;
                return false;
            }
        }

        private bool evaluate(Transform s1, Transform s2, Transform s3, Transform s4, Transform s5, Transform s6, Light l1, Light l2, Light l3)
        {
            if (s1.GetComponent<Slot>().slotedItem == data1 && s2.GetComponent<Slot>().slotedItem == data1 && s3.GetComponent<Slot>().slotedItem == data2
                && s4.GetComponent<Slot>().slotedItem == data3 && s5.GetComponent<Slot>().slotedItem == data3 && s6.GetComponent<Slot>().slotedItem == data3)
            {
                l1.intensity = 30f;
                l2.intensity = 30f;
                l3.intensity = 30f;
                return true;
            }
            return false;
        }
    }
}