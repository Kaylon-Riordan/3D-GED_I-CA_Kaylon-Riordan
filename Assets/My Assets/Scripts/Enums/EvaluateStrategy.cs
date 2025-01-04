namespace GD.Types
{
    /// <summary>
    /// Used in the StateManager to determine how to evaluate a condition.
    /// </summary>
    public enum EvaluateStrategy : sbyte
    {
        /// <summary>
        /// Always evaluate the condition, regardless of whether it is met.
        /// </summary>
        [Description("Always evaluate the condition, regardless of whether it is met.")]
        EvaluateAlways,

        /// <summary>
        /// Evaluate the condition until it is met, then stop evaluating.
        /// </summary>
        [Description("Evaluate the condition until it is met, then stop evaluating.")]
        EvaluateUntilMet
    }
}