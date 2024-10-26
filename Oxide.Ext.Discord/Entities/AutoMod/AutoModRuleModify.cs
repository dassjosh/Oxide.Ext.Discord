using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#modify-auto-moderation-rule-json-params">Auto Mod Rule Modify</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModRuleModify : IDiscordValidation
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
        
        /// <summary>
        /// Rule <see cref="AutoModTriggerType"/>
        /// </summary>
        [JsonIgnore]
        public AutoModTriggerType TriggerType { get; private set; }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="triggerType">Trigger type being modified</param>
        public AutoModRuleModify(AutoModTriggerType triggerType)
        {
            TriggerType = triggerType;
        }
        
        ///<inheritdoc/>
        public void Validate()
        {
            TriggerMetadata?.Validate(TriggerType);
        }
    }
}