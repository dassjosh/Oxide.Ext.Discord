using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#create-auto-moderation-rule-json-params">Auto Mod Rule Create</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModRuleCreate : IDiscordValidation
    {
        /// <summary>
        /// Rule name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Rule <see cref="AutoModEventType"/>
        /// </summary>
        [JsonProperty("event_type")]
        public AutoModEventType EventType { get; set; }
        
        /// <summary>
        /// Rule <see cref="AutoModTriggerType"/>
        /// </summary>
        [JsonProperty("trigger_type")]
        public AutoModTriggerType TriggerType { get; set; }
        
        /// <summary>
        /// Rule <see cref="AutoModTriggerMetadata"/>
        /// </summary>
        [JsonProperty("trigger_metadata")]
        public AutoModTriggerMetadata TriggerMetadata { get; set; }
        
        /// <summary>
        /// Actions which will execute when the rule is triggered
        /// </summary>
        [JsonProperty("actions")]
        public List<AutoModAction> Actions { get; set; }
        
        /// <summary>
        /// Whether the rule is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        
        /// <summary>
        /// Role ids that should not be affected by the rule (Maximum of 20)
        /// </summary>
        [JsonProperty("exempt_roles")]
        public List<Snowflake> ExemptRoles { get; set; }
        
        /// <summary>
        /// Channel ids that should not be affected by the rule (Maximum of 50)
        /// </summary>
        [JsonProperty("exempt_channels")]
        public List<Snowflake> ExemptChannels { get; set; }

        ///<inheritdoc/>
        public void Validate()
        {
            TriggerMetadata?.Validate(TriggerType);
        }
    }
}