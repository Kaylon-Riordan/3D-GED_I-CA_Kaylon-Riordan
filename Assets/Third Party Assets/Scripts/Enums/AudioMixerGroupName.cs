namespace GD.Types
{
    /// <summary>
    /// Represents the various types of audio groups in the game.
    /// </summary>
    public enum AudioMixerGroupName : sbyte
    {
        [Description("Master audio group")]
        Master,

        [Description("Ambient sounds group")]
        Ambient,

        [Description("Background music group")]
        Background,

        [Description("Sound effects group")]
        SFX,

        [Description("UI sounds group")]
        UI,

        [Description("Voiceover group")]
        Voiceover,

        [Description("Weapon sounds group")]
        Weapon
    }
}