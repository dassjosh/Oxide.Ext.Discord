using System;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Entities;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Default Discord Extension provided Placeholder Keys
    /// </summary>
    public static class DefaultKeys
    {
        /// <summary>
        /// <see cref="DiscordApplicationCommand"/> Placeholder Keys
        /// </summary>
        public static readonly AppCommandKeys AppCommand = new("command");
        
        /// <summary>
        /// <see cref="DiscordChannel"/> Placeholder Keys
        /// </summary>
        public static readonly ChannelKeys Channel = new("channel");
        
        /// <summary>
        /// <see cref="DateTime"/> Placeholder Keys
        /// </summary>
        public static readonly DateTimeKeys DateTime = new("datetime");
        
        /// <summary>
        /// <see cref="DateTime"/> Placeholder Keys
        /// </summary>
        public static readonly DateTimeKeys DateTimeNow = new("datetime.now");
        
        /// <summary>
        /// <see cref="DiscordGuild"/> Placeholder Keys
        /// </summary>
        public static readonly GuildKeys Guild = new("guild");
        
        /// <summary>
        /// <see cref="DiscordInteraction"/> Placeholder Keys
        /// </summary>
        public static readonly InteractionKeys Interaction = new("interaction");
        
        /// <summary>
        /// IP address placeholders
        /// </summary>
        public static readonly IpKeys Ip = new("ip");
        
        /// <summary>
        /// <see cref="GuildMember"/> Placeholder Keys
        /// </summary>
        public static readonly MemberKeys Member = new("member");
        
        /// <summary>
        /// <see cref="DiscordMessage"/> Placeholder Keys
        /// </summary>
        public static readonly MessageKeys Message = new("message");
        
        /// <summary>
        /// <see cref="IPlayer"/> Placeholder Keys
        /// </summary>
        public static readonly PlayerKeys Player = new("player");
        
        /// <summary>
        /// <see cref="IPlayer"/> Target Placeholder Keys
        /// </summary>
        public static readonly PlayerKeys PlayerTarget = new("target.player");
        
        /// <summary>
        /// <see cref="Plugin"/> Placeholder Keys
        /// </summary>
        public static readonly PluginKeys Plugin = new("plugin");
        
        /// <summary>
        /// <see cref="ResponseError"/> Placeholder Keys
        /// </summary>
        public static readonly ResponseErrorKeys ResponseError = new("response.error");
        
        /// <summary>
        /// <see cref="DiscordRole"/> Placeholder Keys
        /// </summary>
        public static readonly RoleKeys Role = new("role");
        
        /// <summary>
        /// <see cref="IServer"/> Placeholder Keys
        /// </summary>
        public static readonly ServerKeys Server = new("server");
        
        /// <summary>
        /// <see cref="Snowflake"/> Placeholder Keys
        /// </summary>
        public static readonly SnowflakeKeys Snowflake = new("snowflake");
        
        /// <summary>
        /// <see cref="TimeSpan"/> Placeholder Keys
        /// </summary>
        public static readonly TimespanKeys Timespan = new("timespan");
        
        /// <summary>
        /// Timestamp Placeholder Keys
        /// </summary>
        public static readonly TimestampKeys Timestamp = new("timestamp");
        
        /// <summary>
        /// Timestamp Now Placeholder Keys
        /// </summary>
        public static readonly TimestampKeys TimestampNow = new("timestamp.now");
        
        /// <summary>
        /// <see cref="DiscordUser"/> Placeholder Keys
        /// </summary>
        public static readonly UserKeys User = new("user");
        
        /// <summary>
        /// <see cref="DiscordUser"/> Bot User Placeholder Keys
        /// </summary>
        public static readonly UserKeys Bot = new("bot");
        
        /// <summary>
        /// <see cref="DiscordUser"/> Target Placeholder Keys
        /// </summary>
        public static readonly UserKeys UserTarget = new("target.user");
    }
}