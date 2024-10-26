using Newtonsoft.Json;

namespace Oxide.Ext.Discord.Entities
{
    /// <summary>
    /// Represents <a href="https://discord.com/developers/docs/interactions/application-commands#application-command-permissions-object-application-command-permissions-structure">ApplicationCommandPermissions</a>
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CommandPermissions
    {
        /// <summary>
        /// The ID of the role or user
        /// </summary>
        [JsonProperty("id")]
        public Snowflake Id { get; set; }
        
        /// <summary>
        /// The type of permissions
        /// <see cref="CommandPermissionType"/>
        /// </summary>
        [JsonProperty("type")]
        public CommandPermissionType Type { get; set; }
        
        /// <summary>
        /// True to allow, False to disallow
        /// </summary>
        [JsonProperty("permission")]
        public bool Permission { get; set; }

        /// <summary>
        /// Creates a new CommandPermissions that allows all guild members to use the application command
        /// </summary>
        /// <param name="guild">Guild to allow the application command in</param>
        /// <returns><see cref="CommandPermissions"/></returns>
        public static CommandPermissions AllowAllGuildMembers(DiscordGuild guild)
        {
            return new CommandPermissions
            {
                Id = guild.Id,
                Type = CommandPermissionType.Role,
                Permission = true
            };
        }
        
        /// <summary>
        /// Creates a new CommandPermissions that allows the application command to be used in all guild channels
        /// </summary>
        /// <param name="guild">Guild to allow the application command in</param>
        /// <returns><see cref="CommandPermissions"/></returns>
        public static CommandPermissions AllowAllGuildChannels(DiscordGuild guild)
        {
            return new CommandPermissions
            {
                Id = new Snowflake(guild.Id.Id - 1),
                Type = CommandPermissionType.Role,
                Permission = true
            };
        }
    }
}