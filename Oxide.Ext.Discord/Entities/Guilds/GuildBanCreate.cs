using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#create-guild-ban">Guild Ban Create Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildBanCreate : IDiscordValidation
    {
        /// <summary>
        /// Number of seconds to delete messages for, between 0 and 604800 (7 days)
        /// </summary>
        [JsonProperty("delete_message_seconds")]
        public int? DeleteMessageSeconds { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            InvalidGuildBanException.ThrowIfInvalidDeleteMessageSeconds(DeleteMessageSeconds);
        }
    }
}