﻿using Newtonsoft.Json;
using Oxide.Ext.Discord.Json;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#guild-emojis-update">Guild Emojis Update</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildEmojisUpdatedEvent
    {
        /// <summary>
        /// ID of the guild
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }

        /// <summary>
        /// List of emojis
        /// </summary>
        [JsonConverter(typeof(HashListConverter<DiscordEmoji>))]
        [JsonProperty("emojis")]
        public Hash<Snowflake, DiscordEmoji> Emojis { get; set; }
    }
}