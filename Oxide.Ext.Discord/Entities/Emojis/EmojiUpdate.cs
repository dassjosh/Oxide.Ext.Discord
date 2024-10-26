using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/emoji#modify-guild-emoji-json-params">Emoji Update Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class EmojiUpdate : IDiscordValidation
    {
        /// <summary>
        /// Emoji name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Roles this emoji is whitelisted to
        /// </summary>
        [JsonProperty("roles")]
        public List<Snowflake> Roles { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidEmojiException.ThrowIfInvalidName(Name, true);
        }
    }
}