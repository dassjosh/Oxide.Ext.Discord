using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/message-components#component-object">Message Component</a> within discord
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public abstract class BaseComponent : IDiscordValidation
    {
        /// <summary>
        /// Message component type
        /// </summary>
        [JsonProperty("type")]
        public MessageComponentType Type { get; protected set; }

        ///<inheritdoc />
        public abstract void Validate();
    }
}