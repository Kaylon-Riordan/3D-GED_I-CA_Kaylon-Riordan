namespace GD.Types
{
    /// <summary>
    /// Defines the various specific types of items available in a game.
    /// These types are grouped under the broader categories represented by ItemCategoryType.
    /// </summary>
    /// <see cref="GD.Items.ItemData"/>
    /// <see cref="GD.Inventory"/>
    public enum ItemType : sbyte
    {
        /// <summary>
        /// Represents a clue or hint used to assist in solving puzzles.
        /// </summary>
        [Description("Clue or hint used to assist in solving puzzles")]
        Clue
    }
}