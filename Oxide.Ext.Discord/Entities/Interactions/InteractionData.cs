using System.Collections.Generic;
using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/receiving-and-responding#interaction-object-interaction-data">ApplicationCommandInteractionData</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class InteractionData
    {
        /// <summary>
        /// ID of the invoked command
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Name of the invoked command
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
            
        /// <summary>
        /// Type of the invoked command
        /// </summary>
        [JsonProperty("type")]
        public ApplicationCommandType? Type { get; set; }
        
        /// <summary>
        /// Converted <see cref="DiscordUser"/>s, <see cref="DiscordRole"/>s, <see cref="DiscordChannel"/>s, <see cref="GuildMember"/>s, <see cref="DiscordMessage"/>s <see cref="MessageAttachment"/>s
        /// </summary>
        [JsonProperty("resolved")]
        public InteractionDataResolved Resolved { get; set; }
        
        /// <summary>
        /// Params + values from the user
        /// </summary>
        [JsonProperty("options")]
        public List<InteractionDataOption> Options { get; set; }
            
        /// <summary>
        /// ID of the guild the command is registered to
        /// </summary>
        [JsonProperty("guild_id")]
        public Snowflake? GuildId { get; set; }
        
        /// <summary>
        /// For components, the custom_id of the component
        /// </summary>
        [JsonProperty("custom_id")]
        public string CustomId { get; set; }
        
        /// <summary>
        /// For components, the type of the component
        /// </summary>
        [JsonProperty("component_type")]
        public MessageComponentType? ComponentType { get; set; }
        
        /// <summary>
        /// For components, the values for the select menu component
        /// </summary>
        [JsonProperty("values")]
        public List<string> Values { get; set; }
        
        /// <summary>
        /// ID of user or message targeted by a user or message command
        /// </summary>
        [JsonProperty("target_id")]
        public Snowflake? TargetId { get; set; }
        
        /// <summary>
        /// The values submitted by the user (Modal Submit)
        /// </summary>
        [JsonProperty("components")]
        public List<ActionRowComponent> Components { get; set; }
        
        /// <summary>
        /// Returns a Component of type {T} with a custom ID that equals customId 
        /// </summary>
        /// <param name="customId">Custom ID to match on</param>
        /// <typeparam name="T">Type to return</typeparam>
        /// <returns></returns>
        public T GetComponent<T>(string customId) where T : BaseInteractableComponent
        {
            foreach (ActionRowComponent row in Components)
            {
                foreach (BaseComponent baseComponent in row.Components)
                {
                    if (baseComponent is T component && component.CustomId == customId)
                    {
                        return component;
                    }
                }
            }

            return null;
        }
    }
}