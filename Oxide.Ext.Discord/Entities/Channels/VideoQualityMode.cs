namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#channel-object-video-quality-modes">Video Quality Mode</a>
    /// </summary>
    public enum VideoQualityMode : byte
    {
        /// <summary>
        /// Discord chooses the quality for optimal performance
        /// </summary>
        Auto = 1,
        
        /// <summary>
        /// 720p
        /// </summary>
        Full = 2
    }
}