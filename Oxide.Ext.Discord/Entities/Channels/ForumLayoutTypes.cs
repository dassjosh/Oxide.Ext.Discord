namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#channel-object-forum-layout-types">Forum Layout Types</a>
    /// </summary>
    public enum ForumLayoutTypes : byte
    {
        /// <summary>
        /// No default has been set for forum channel
        /// </summary>
        NotSet = 0,
        
        /// <summary>
        /// Display posts as a list
        /// </summary>
        ListView = 1,
        
        /// <summary>
        /// Display posts as a collection of tiles
        /// </summary>
        GalleryView = 2,
    }
}