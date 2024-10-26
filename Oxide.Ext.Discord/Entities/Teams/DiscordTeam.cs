using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Helpers;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents a <a href="https://discord.com/developers/docs/topics/teams#data-models-team-object">Team Object</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DiscordTeam
    {
        /// <summary>
        /// Unique ID of the team
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// Hash of the image of the team's icon
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        
        /// <summary>
        /// Members of the team
        /// See <see cref="TeamMember"/>
        /// </summary>
        [JsonProperty("members")]
        public List<TeamMember> Members { get; set; }
        
        /// <summary>
        /// Name of the team
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// User ID of the current team owner
        /// </summary>
        [JsonProperty("owner_user_id")]
        public Snowflake OwnerUserId { get; set; }
        
        /// <summary>
        /// Role of the team member
        /// </summary>
        [JsonProperty("role")]
        public TeamRole Role { get; set; }

        /// <summary>
        /// Returns the url for the team icon
        /// </summary>
        public string GetTeamIconUrl => DiscordCdn.GetTeamIconUrl(Id, Icon);
    }
}