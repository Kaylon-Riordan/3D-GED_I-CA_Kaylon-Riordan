namespace GD.Types
{
    /// <summary>
    /// Represents the various types of audio groups in the game.
    /// </summary>
    /// <summary>
    /// Represents the state of a UI element, such as visible, hidden, or transitioning.
    /// </summary>
    public enum VisibilityState : sbyte
    {
        [Description("The UI element has tween applied.")]
        End,

        [Description("The UI element is transitioning to a visible state.")]
        Showing,

        [Description("The UI element is transitioning to a hidden state.")]
        Hiding,

        [Description("The UI element has not yet had tween applied.")]
        Start
    }
}
