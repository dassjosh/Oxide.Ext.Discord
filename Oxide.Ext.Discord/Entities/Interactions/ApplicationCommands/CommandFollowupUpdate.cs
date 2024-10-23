using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="">Command Followup</a> within discord.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandFollowupUpdate : WebhookEditMessage
    {
        /// <summary>
        /// Callback data flags
        /// Set to 64 to make your response ephemeral
        /// </summary>
        [JsonProperty("flags")]
        public MessageFlags? Flags { get; set; }
    }
}