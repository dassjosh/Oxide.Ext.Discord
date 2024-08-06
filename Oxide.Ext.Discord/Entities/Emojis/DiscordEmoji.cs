﻿using System;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Helpers;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/resources/emoji#emoji-object">Emoji Structure</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class DiscordEmoji : EmojiUpdate, ISnowflakeEntity
{
    /// <summary>
    /// The ID for the emoji if it is custom; Otherwise invalid snowflake
    /// </summary>
    public Snowflake Id => EmojiId ?? default(Snowflake);

    /// <summary>
    /// Emoji id
    /// </summary>
    [JsonProperty("id")]
    public Snowflake? EmojiId { get; set; }

    /// <summary>
    /// User that created this emoji
    /// </summary>
    [JsonProperty("user")]
    public DiscordUser User { get; set; }

    /// <summary>
    /// Whether this emoji must be wrapped in colons
    /// </summary>
    [JsonProperty("require_colons")]
    public bool? RequireColons { get; set; }

    /// <summary>
    /// Whether this emoji is managed
    /// </summary>
    [JsonProperty("managed")]
    public bool? Managed { get; set; }

    /// <summary>
    /// Whether this emoji is animated
    /// </summary>
    [JsonProperty("animated")]
    public bool? Animated { get; set; }
        
    /// <summary>
    /// Whether this emoji can be used, may be false due to loss of Server Boosts
    /// </summary>
    [JsonProperty("available")]
    public bool? Available { get; set; }
        
    /// <summary>
    /// Url to the emoji image
    /// </summary>
    public string Url => EmojiId.HasValue ? DiscordCdn.GetCustomEmojiUrl(EmojiId.Value, Animated.HasValue && Animated.Value ? DiscordImageFormat.Gif : DiscordImageFormat.Png) : null;

    /// <summary>
    /// Show the emoji in a message
    /// </summary>
    public string Mention => DiscordFormatting.EmojiMessageString(this);

    /// <summary>
    /// Returns an emoji object for the given emoji character
    /// </summary>
    /// <param name="emoji"></param>
    /// <returns></returns>
    public static DiscordEmoji FromCharacter(string emoji)
    {
        return new DiscordEmoji
        {
            Name = emoji
        };
    }

    /// <summary>
    /// Returns an Emoji object from a custom emoji ID and Animated flag
    /// </summary>
    /// <param name="id">ID of the emoji</param>
    /// <param name="animated">If the emoji is animated</param>
    /// <returns></returns>
    public static DiscordEmoji FromCustom(Snowflake id, bool animated = false)
    {
        return new DiscordEmoji
        {
            EmojiId = id,
            Animated = animated
        };
    }
        
    /// <summary>
    /// Returns the data string to be used in the API request
    /// </summary>
    /// <returns></returns>
    public string ToDataString()
    {
        if (!EmojiId.HasValue)
        {
            return Name;
        }

        return Uri.EscapeDataString(DiscordFormatting.CustomEmojiDataString(EmojiId.Value, Name, Animated ?? false));
    }

    internal void Update(DiscordEmoji emoji)
    {
        if (emoji.Name != null) Name = emoji.Name;
        if (emoji.Roles != null) Roles = emoji.Roles;
        if (emoji.User != null) User = emoji.User;
        if (emoji.RequireColons != null) RequireColons = emoji.RequireColons;
        if (emoji.Managed != null) Managed = emoji.Managed;
        if (emoji.Animated != null) Animated = emoji.Animated;
        if (emoji.Available != null) Available = emoji.Available;
    }
}