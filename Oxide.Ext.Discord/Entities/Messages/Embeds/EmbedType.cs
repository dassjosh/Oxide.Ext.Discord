using Newtonsoft.Json;
using Oxide.Ext.Discord.Attributes;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities;

[JsonConverter(typeof(DiscordEnumConverter))]
public enum EmbedType
{
    /// <summary>
    /// Generic embed rendered from embed attributes
    /// </summary>
    [DiscordEnum("rich")]
    Rich,
    
    /// <summary>
    /// Image embed
    /// </summary>
    [DiscordEnum("image")]
    Image,
    
    /// <summary>
    /// Video embed
    /// </summary>
    [DiscordEnum("video")]
    Video,
    
    /// <summary>
    /// Animated gif image embed rendered as a video embed
    /// </summary>
    [DiscordEnum("gifv")]
    Gifv,
    
    /// <summary>
    /// Article embed
    /// </summary>
    [DiscordEnum("article")]
    Article,
    
    /// <summary>
    /// Link embed
    /// </summary>
    [DiscordEnum("link")]
    Link,
    
    /// <summary>
    /// Poll result embed
    /// </summary>
    [DiscordEnum("poll_result")]
    PollResult,
}