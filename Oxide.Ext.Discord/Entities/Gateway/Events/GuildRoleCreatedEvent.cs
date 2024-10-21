﻿using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities;

/// <summary>
/// Represents <a href="https://discord.com/developers/docs/topics/gateway#guild-role-create">Guild Role Create</a>
/// </summary>
[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
public class GuildRoleCreatedEvent
{
    /// <summary>
    /// The id of the guild
    /// </summary>
    [JsonProperty("guild_id")]
    public Snowflake GuildId { get; set; }

    /// <summary>
    /// The role created
    /// </summary>
    [JsonProperty("role")]
    public DiscordRole Role { get; set; }
}