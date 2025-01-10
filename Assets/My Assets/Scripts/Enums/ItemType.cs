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
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        [Description("Items used to add resistance to circuit")]
        Batteries,

        /// <summary>
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        [Description("Items used to unlock or solve puzzles or progress the storyline")]
        Bulbs,

        /// <summary>
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        [Description("Items used to unlock or solve puzzles or progress the storyline")]
        Resistors

    }
}