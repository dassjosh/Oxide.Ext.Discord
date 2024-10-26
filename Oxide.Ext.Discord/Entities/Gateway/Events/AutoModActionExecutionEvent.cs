using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/topics/gateway#auto-moderation-action-execution-auto-moderation-action-execution-event-fields">Auto Moderation Action Execution Event</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModActionExecutionEvent
    {
        /// <summary>
        /// Id of the guild in which action was executed
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
        
        /// <summary>
        /// The action which was executed
        /// </summary>
        [JsonProperty("action")]
        public AutoModAction Action { get; set; }
        
        /// <summary>
        /// Id of the rule which action belongs to
        /// </summary>
        [JsonProperty("rule_id")]
        public Snowflake RuleId { get; set; }
        
        /// <summary>
        /// The <see cref="AutoModTriggerType"/> of rule which was triggered
        /// </summary>
        [JsonProperty("rule_trigger_type")]
        public AutoModTriggerType RuleTriggerType { get; set; }
        
        /// <summary>
        /// Id of the user which generated the content which triggered the rule
        /// </summary>
        [JsonProperty("user_id")]
        public Snowflake? UserId { get; set; }
        
        /// <summary>
        /// Id of any user message which content belongs to
        /// </summary>
        [JsonProperty("message_id")]
        public Snowflake? MessageId { get; set; }
        
        /// <summary>
        /// The id of any system auto moderation messages posted as a result of this action
        /// </summary>
        [JsonProperty("alert_system_message_id")]
        public Snowflake? AlertSystemMessageId { get; set; }
        
        /// <summary>
        /// The user generated text content
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
        
        /// <summary>
        /// The word or phrase configured in the rule that triggered the rule
        /// </summary>
        [JsonProperty("matched_keyword")]
        public string MatchedKeyword { get; set; }
        
        /// <summary>
        /// The substring in content that triggered the rule
        /// </summary>
        [JsonProperty("matched_content")]
        public string MatchedContent { get; set; }
    }
}