using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/topics/gateway#voice-server-update">Voice Server Update</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class VoiceChannelEffectEvent
{
    /// <summary>
    /// ID of the channel the effect was sent in
    /// </summary>
    [JsonProperty("channel_id")]
    public Snowflake ChannelId { get; set; }
    
    /// <summary>
    /// ID of the guild the effect was sent in
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake GuildId { get; set; }
    
    /// <summary>
    /// ID of the user who sent the effect
    /// </summary>
    [JsonProperty("user_id")]
    public Snowflake UserId { get; set; }

    /// <summary>
    /// The emoji sent, for emoji reaction and soundboard effects
    /// </summary>
    [JsonProperty("emoji")]
    public DiscordEmoji Emoji { get; set; }
    
    
    /// <summary>
    /// The type of emoji animation, for emoji reaction and soundboard effects
    /// </summary>
    [JsonProperty("animation_type")]
    public AnimationType AnimationType { get; set; }
    
    /// <summary>
    /// The ID of the emoji animation, for emoji reaction and soundboard effects
    /// </summary>
    [JsonProperty("animation_id")]
    public int? AnimationId { get; set; }
    
    /// <summary>
    /// The ID of the soundboard sound, for soundboard effects
    /// </summary>
    [JsonProperty("sound_id")]
    public ulong? SoundId { get; set; }
    
    /// <summary>
    /// The volume of the soundboard sound, from 0 to 1, for soundboard effects
    /// </summary>
    [JsonProperty("sound_volume")]
    public double? SoundVolume { get; set; }
}