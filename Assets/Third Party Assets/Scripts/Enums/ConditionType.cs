namespace GD.Types
{
    /// <summary>
    /// Used in the StateManager to determine how to evaluate a condition.
    /// </summary>
    public enum ConditionType : sbyte
    {
        [Description("Evaluate all conditions and return true if all are met.")]
        And,

        [Description("Evaluate all conditions and return true if any are met.")]
        Or,

        [Description("Evaluate all conditions and return true if only one is met.")]
        Xor
    }
}