using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-callback-interaction-callback-object">Interaction Callback Object</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionCallback
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
    
        /// <summary>
        /// Interaction Type
        /// </summary>
        [JsonProperty("type")]
        public InteractionType Type { get; set; }
    
        /// <summary>
        /// Instance ID of the Activity if one was launched or joined
        /// </summary>
        [JsonProperty("activity_instance_id")]
        public string ActivityInstanceId { get; set; }
    
        /// <summary>
        /// ID of the message that was created by the interaction
        /// </summary>
        [JsonProperty("response_message_id")]
        public Snowflake? ResponseMessageId { get; set; }
    
        /// <summary>
        /// Whether or not the message is in a loading state
        /// </summary>
        [JsonProperty("response_message_loading")]
        public bool? ResponseMessageLoading { get; set; }
    
        /// <summary>
        /// Whether or not the response message was ephemeral
        /// </summary>
        [JsonProperty("response_message_ephemeral")]
        public bool? ResponseMessageEphemeral { get; set; }
    }
}