using System.Collections.Generic;
using GD.Items;
using NUnit.Framework;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A condition that circuit 1 is correctly completed.
    /// </summary>
    [CreateAssetMenu(fileName = "CircuitCondition1", menuName = "GD/Conditions/Single/C1", order = 2)]
    public class CircuitCondition1 : ConditionBase
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

        protected override bool EvaluateCondition(ConditionContext conditionContext)
        {
            if(evaluate(slot1, slot2, slot3, light3))
            {
                return true;
            }
            else if (evaluate(slot2, slot3, slot1, light1))
            {
                return true;
            }
            else if (evaluate(slot3, slot1, slot2, light2))
            {
                return true;
            }
            else
            {
                light1.intensity = 0f;
                light2.intensity = 0f;
                light3.intensity = 0f;
                return false;
            }
        }

        private bool evaluate(Transform s1, Transform s2, Transform s3, Light l)
        {
            if (s1.GetComponent<Slot>().slotedItem == data1 && s2.GetComponent<Slot>().slotedItem == data2 && s3.GetComponent<Slot>().slotedItem == data3)
            {
                l.intensity = 500f;
                return true;
            }
            return false;
        }
    }
}