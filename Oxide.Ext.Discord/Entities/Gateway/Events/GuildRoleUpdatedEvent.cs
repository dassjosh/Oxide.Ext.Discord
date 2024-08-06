﻿using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/topics/gateway#guild-role-update">Guild Role Update</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class GuildRoleUpdatedEvent
{
    /// <summary>
    /// The id of the guild
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake GuildId { get; set; }

    /// <summary>
    /// The role updated
    /// </summary>
    [JsonProperty("role")]
    public DiscordRole Role { get; set; }
}