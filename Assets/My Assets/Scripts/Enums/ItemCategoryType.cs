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
        /// Items used to unlock or solve puzzles or progress the storyline.
        /// </summary>
        [Description("Items used to unlock or solve puzzles or progress the storyline")]
        PuzzleItem,

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