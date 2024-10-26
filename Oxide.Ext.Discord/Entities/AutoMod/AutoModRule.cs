using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Interfaces;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/auto-moderation#auto-moderation-rule-object">Auto Mod Rule</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class AutoModRule
    {
        /// <summary>
        /// Id of this rule
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// ID of the Guild which this rule belongs to
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake GuildId { get; set; }
        
        /// <summary>
        /// Rule name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// User which first created this rule
        /// </summary>
        [JsonProperty("creator_id")]
        public Snowflake CreatorId { get; set; }
        
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
        
        /// <summary>
        /// Modify an existing rule
        /// Requires <see cref="PermissionFlags.ManageGuild"/> permissions.
        /// See <a href="https://discord.com/developers/docs/resources/auto-moderation#list-auto-moderation-rules-for-guild">List Auto Moderation Rules for Guild</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild ID to list the rules for</param>
        public static IPromise<List<AutoModRule>> GetAll(DiscordClient client, Snowflake guildId)
        {
            return client.Bot.Rest.Get<List<AutoModRule>>(client,$"guilds/{guildId}/auto-moderation/rules");
        }
        
        /// <summary>
        /// Get a single rule
        /// Requires <see cref="PermissionFlags.ManageGuild"/> permissions.
        /// See <a href="https://discord.com/developers/docs/resources/auto-moderation#get-auto-moderation-rule">Get Auto Moderation Rule</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild ID of the rule</param>
        /// <param name="ruleId">Rule ID to get the rule for</param>
        public static IPromise<AutoModRule> Get(DiscordClient client, Snowflake guildId, Snowflake ruleId)
        {
            return client.Bot.Rest.Get<AutoModRule>(client,$"guilds/{guildId}/auto-moderation/rules/{ruleId}");
        }
        
        /// <summary>
        /// Create a new rule
        /// Requires <see cref="PermissionFlags.ManageGuild"/> permissions.
        /// See <a href="https://discord.com/developers/docs/resources/auto-moderation#create-auto-moderation-rule">Create Auto Moderation Rule</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="guildId">Guild ID of the rule</param>
        /// <param name="create">Rule to be created</param>
        public static IPromise<AutoModRule> Create(DiscordClient client, Snowflake guildId, AutoModRuleCreate create)
        {
            return client.Bot.Rest.Post<AutoModRule>(client,$"guilds/{guildId}/auto-moderation/rules", create);
        }
        
        /// <summary>
        /// Modify an existing rule
        /// Requires <see cref="PermissionFlags.ManageGuild"/> permissions.
        /// See <a href="https://discord.com/developers/docs/resources/auto-moderation#modify-auto-moderation-rule">Modify Auto Moderation Rule</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        /// <param name="modify"><see cref="AutoModRuleModify"/></param>
        public IPromise<AutoModRule> Edit(DiscordClient client, AutoModRuleModify modify)
        {
            return client.Bot.Rest.Patch<AutoModRule>(client,$"guilds/{GuildId}/auto-moderation/rules/{Id}", modify);
        }
        
        /// <summary>
        /// Delete a rule
        /// Requires <see cref="PermissionFlags.ManageGuild"/> permissions.
        /// See <a href="https://discord.com/developers/docs/resources/auto-moderation#delete-auto-moderation-rule">Delete Auto Moderation Rule</a>
        /// </summary>
        /// <param name="client">Client to use</param>
        public IPromise Delete(DiscordClient client)
        {
            return client.Bot.Rest.Delete(client,$"guilds/{GuildId}/auto-moderation/rules/{Id}");
        }
    }
}