using Newtonsoft.Json;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#modify-channel-json-params-group-dm">Group DM Channel Update Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GroupDmChannelUpdate : IDiscordValidation
    {
        /// <summary>
        /// The name of the channel (1-100 characters)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Base64 encoded icon
        /// </summary>
        [JsonProperty("icon")]
        public DiscordImageData? Icon { get; set; }

        /// <inheritdoc/>
        public void Validate()
        {
            InvalidChannelException.ThrowIfInvalidName(Name, true);
        }
    }
}