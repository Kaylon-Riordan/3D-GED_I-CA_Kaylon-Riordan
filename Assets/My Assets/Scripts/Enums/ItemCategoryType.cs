namespace GD.Types
{
    /// <summary>
    /// Defines the various high-level categories of items available in a game.
    /// Each category groups similar item types under one classification.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    public enum ItemCategoryType : sbyte
    {
        /// <summary>
        /// Items used to complete gaps in a circuit.
        /// </summary>
        [Description("Items used to complete gaps in a circuit")]
        Electronics

    }
}