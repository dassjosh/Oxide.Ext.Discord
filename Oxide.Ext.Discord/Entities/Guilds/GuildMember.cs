using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/resources/guild#guild-member-object-guild-member-structure">Guild Member Structure</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GuildMember : ISnowflakeEntity
    {
        #region Discord Fields
        /// <summary>
        /// Id for guild member
        /// </summary>
        public Snowflake Id => User?.Id ?? default(Snowflake);

        /// <summary>
        /// The user this guild member represents
        /// </summary>
        [JsonProperty("user")]
        public DiscordUser User { get; set; }

        /// <summary>
        /// This users guild nickname
        /// </summary>
        [JsonProperty("nick")]
        public string Nickname { get; set; }
        
        /// <summary>
        /// The member's guild avatar hash
        /// </summary>
        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// List of member roles
        /// </summary>
        [JsonProperty("roles")]
        public List<Snowflake> Roles { get; set; }

        /// <summary>
        /// When the user joined the guild
        /// </summary>
        [JsonProperty("joined_at")]
        public DateTime? JoinedAt { get; set; }

        /// <summary>
        /// When the user started boosting the guild
        /// </summary>
        [JsonProperty("premium_since")]
        public DateTime? PremiumSince { get; set; }
        
        /// <summary>
        /// Total permissions of the member in the channel, including overrides, returned when in the interaction object
        /// </summary>
        [JsonConverter(typeof(PermissionFlagsStringConverter))]
        [JsonProperty("permissions")]
        public PermissionFlags? Permissions { get; set; }
        
        /// <summary>
        /// Whether the user is deafened in voice channels
        /// </summary>
        [JsonProperty("deaf")]
        public bool Deaf { get; set; }

        /// <summary>
        /// Whether the user is muted in voice channels
        /// </summary>
        [JsonProperty("mute")]
        public bool Mute { get; set; }
        
        /// <summary>
        /// Flags for the GuildMember
        /// </summary>
        [JsonProperty("flags")]
        public GuildMemberFlags Flags { get; set; }

        /// <summary>
        /// Whether the user has not yet passed the guild's Membership Screening requirements
        /// </summary>
        [JsonProperty("pending")]
        public bool? Pending { get; set; }
        
        /// <summary>
        /// When the user's timeout will expire and the user will be able to communicate in the guild again, null or a time in the past if the user is not timed out
        /// </summary>
        [JsonProperty("communication_disabled_until")]
        public DateTime? CommunicationDisabledUntil { get; set; }
        
        /// <summary>
        /// Data for the member's guild avatar decoration
        /// </summary>
        [JsonProperty("avatar_decoration_data")]
        public AvatarDecorationData AvatarDecoration { get; set; }
        #endregion

        #region Extension Fields
        /// <summary>
        /// When the Nickname was last updated UTC. Null if we haven't seen a nickname update yet
        /// </summary>
        public DateTime? NickNameLastUpdated { get; internal set; }
        
        /// <summary>
        /// Returns if the <see cref="GuildMember"/> has left the <see cref="DiscordGuild"/> it belongs to
        /// </summary>
        public bool HasLeftGuild { get; internal set; }
        #endregion
        
        #region Helper Properties
        /// <summary>
        /// Returns the display name show for the user in a guild
        /// </summary>
        public string DisplayName => string.IsNullOrEmpty(Nickname) ? User?.DisplayName : Nickname;
        
        /// <summary>
        /// Returns if the GuildMember is a bot
        /// </summary>
        public bool IsBot => User.Bot.HasValue && User.Bot.Value;
        #endregion
        
        #region Helper Methods
        /// <summary>
        /// Returns if member has the given role
        /// </summary>
        /// <param name="role">Role to check</param>
        /// <returns>Return true if has role; False otherwise;</returns>
        /// <exception cref="ArgumentNullException">Thrown if role is null</exception>
        public bool HasRole(DiscordRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            
            return HasRole(role.Id);
        }

        /// <summary>
        /// Returns if member has the given role
        /// </summary>
        /// <param name="roleId">Role ID to check</param>
        /// <returns>Return true if has role; False otherwise;</returns>
        public bool HasRole(Snowflake roleId) => Roles.Contains(roleId);
        #endregion
    }
}