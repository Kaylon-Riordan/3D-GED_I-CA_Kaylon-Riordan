namespace GD.Types
{
    /// <summary>
    /// Represents the various types of audio groups in the game.
    /// </summary>
    public enum AudioMixerGroupName : sbyte
    {
        [Description("Master audio group")]
        Master,

        [Description("Sound effects group")]
        SFX,

        [Description("Music group")]
        Music
    }
}