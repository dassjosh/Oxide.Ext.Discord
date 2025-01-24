namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/reference#image-formatting-image-formats">Image Formats</a>
    /// </summary>
    public enum DiscordSoundFormat : byte
    {
        /// <summary>
        /// Automatically pick the sound format
        /// </summary>
        Auto,
        
        /// <summary>
        /// Data is MP3
        /// </summary>
        Mp3,
        
        /// <summary>
        /// Data is OGG
        /// </summary>
        Ogg
    }
}