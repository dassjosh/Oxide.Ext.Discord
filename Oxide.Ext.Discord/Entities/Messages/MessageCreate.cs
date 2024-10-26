using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/resources/channel#create-message-jsonform-params">Message Create Structure</a> to be created in discord
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class MessageCreate : BaseMessageCreate
    {
        /// <summary>
        /// Can be used to verify a message was sent (up to 25 characters).
        /// Value will appear in the Message Create event.
        /// </summary>
        [JsonProperty("nonce")]
        public string Nonce { get; set; }
        
        /// <summary>
        /// If true and nonce is present, it will be checked for uniqueness in the past few minutes. If another message was created by the same author with the same nonce, that message will be returned and no new message will be created.
        /// </summary>
        [JsonProperty("enforce_nonce")]
        public bool EnforceNonce { get; set; }
        
        /// <summary>
        /// Include to make your message a reply or a forward
        /// </summary>
        [JsonProperty("message_reference")]
        public MessageReference MessageReference { get; set; }
    }
}