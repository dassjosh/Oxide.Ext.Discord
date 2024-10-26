using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Extensions
{
    /// <summary>
    /// IPlayer Extensions for sending Discord Message to an IPlayer
    /// </summary>
    public static class PlayerExt
    {
        /// <summary>
        /// Send a Discord Message to an IPlayer if they're registered
        /// </summary>
        /// <param name="player">Player to send the discord message to</param>
        /// <param name="client">Client to use for sending the message</param>
        /// <param name="message">Message to send</param>
        public static IPromise<DiscordMessage> SendDiscordMessage(this IPlayer player, DiscordClient client, string message)
        {
            MessageCreate create = new()
            {
                Content = message
            };
            
            return player.SendDiscordMessage(client, create);
        }

        /// <summary>
        /// Send a Discord Message to an IPlayer if they're registered
        /// </summary>
        /// <param name="player">Player to send the discord message to</param>
        /// <param name="client">Client to use for sending the message</param>
        /// <param name="embed">Embed to send</param>
        public static IPromise<DiscordMessage> SendDiscordMessage(this IPlayer player, DiscordClient client, DiscordEmbed embed)
        {
            MessageCreate create = new()
            {
                Embeds = new List<DiscordEmbed> {embed}
            };
            
            return player.SendDiscordMessage(client, create);
        }
        
        /// <summary>
        /// Send a Discord Message to an IPlayer if they're registered
        /// </summary>
        /// <param name="player">Player to send the discord message to</param>
        /// <param name="client">Client to use for sending the message</param>
        /// <param name="embeds">Embeds to send</param>
        public static IPromise<DiscordMessage> SendDiscordMessage(this IPlayer player, DiscordClient client, List<DiscordEmbed> embeds)
        {
            MessageCreate create = new()
            {
                Embeds = embeds
            };
            
            return player.SendDiscordMessage(client, create);
        }
        
        /// <summary>
        /// Send a Discord Message to an IPlayer if they're registered
        /// </summary>
        /// <param name="player">Player to send the discord message to</param>
        /// <param name="client">Client to use for sending the message</param>
        /// <param name="message">Message to send</param>
        public static IPromise<DiscordMessage> SendDiscordMessage(this IPlayer player, DiscordClient client, MessageCreate message)
        {
            return SendMessage(client, player.GetDiscordUserId(), message);
        }

        /// <summary>
        /// Send a message in a DM to the linked user using a global message template
        /// </summary>
        /// <param name="player">Player to send the message to</param>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        public static IPromise<DiscordMessage> SendDiscordGlobalTemplateMessage(this IPlayer player, DiscordClient client, TemplateKey templateName, MessageCreate message = null, PlaceholderData placeholders = null)
        {
            MessageCreate template = DiscordExtension.DiscordMessageTemplates.GetPlayerTemplate(client.Plugin, templateName, player).ToMessage(placeholders, message);
            return SendMessage(client, player.GetDiscordUserId(), template);
        }

        /// <summary>
        /// Send a message in a DM to the linked user using a localized message template
        /// </summary>
        /// <param name="player">Player to send the message to</param>
        /// <param name="client">Client to use</param>
        /// <param name="templateName">Template Name</param>
        /// <param name="message">Message to use (optional)</param>
        /// <param name="placeholders">Placeholders to apply (optional)</param>
        public static IPromise<DiscordMessage> SendDiscordTemplateMessage(this IPlayer player, DiscordClient client, TemplateKey templateName, MessageCreate message = null, PlaceholderData placeholders = null)
        {
            MessageCreate template = DiscordExtension.DiscordMessageTemplates.GetPlayerTemplate(client.Plugin, templateName, player).ToMessage(placeholders, message);
            return SendMessage(client, player.GetDiscordUserId(), template);
        }
        
        private static IPromise<DiscordMessage> SendMessage(DiscordClient client, Snowflake? id, MessageCreate message)
        {
            if (!client.IsConnected())
            {
                return Promise<DiscordMessage>.Rejected(DiscordClientException.NotConnected());
            }
            
            if (!id.HasValue)
            {
                return Promise<DiscordMessage>.Rejected(InvalidSnowflakeException.InvalidException(nameof(id)));
            }
            
            DiscordChannel channel = client.Bot.DirectMessagesByUserId[id.Value];
            if (channel != null)
            {
                return channel.CreateMessage(client, message);
            }

            DiscordUser user = EntityCache<DiscordUser>.Instance.GetOrCreate(id.Value);
            return user.SendDirectMessage(client, message);
        }

        /// <summary>
        /// Returns true if the player is linked
        /// </summary>
        /// <param name="player">Player to check if they're linked</param>
        /// <returns>True if linked; False otherwise</returns>
        public static bool IsLinked(this IPlayer player) => player != null && DiscordLink.Instance.IsLinked(player.Id);

        /// <summary>
        /// Returns the Discord ID of the IPlayer if linked
        /// </summary>
        /// <param name="player">Player to get Discord ID for</param>
        /// <returns>Discord ID if linked; null otherwise</returns>
        public static Snowflake GetDiscordUserId(this IPlayer player) => player != null ? DiscordLink.Instance.GetDiscordId(player) : default;

        /// <summary>
        /// Returns a minimal Discord User for the given player
        /// </summary>
        /// <param name="player">Player to get Discord User for</param>
        /// <returns>Discord User if linked; null otherwise</returns>
        public static DiscordUser GetDiscordUser(this IPlayer player) => player != null ? DiscordLink.Instance.GetDiscordUser(player) : null;

        /// <summary>
        /// Returns a minimal Guild Member for the given player
        /// </summary>
        /// <param name="player">Player to get Discord User for</param>
        /// <param name="guild">Guild the member is in</param>
        /// <returns>GuildMember if linked and in guild; null otherwise</returns>
        public static GuildMember GetGuildMember(this IPlayer player, DiscordGuild guild) => player != null ? DiscordLink.Instance.GetLinkedMember(player, guild) : null;

        /// <summary>
        /// Returns the PlayerId for a given <see cref="IPlayer"/>
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static PlayerId PlayerId(this IPlayer player) => player != null ? new PlayerId(player.Id) : default;
        
        /// <summary>
        /// Returns if the IPlayer is a <see cref="DiscordDummyPlayer"/>
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool IsDummyPlayer(this IPlayer player) => player is DiscordDummyPlayer;

        /// <summary>
        /// Allows plugins to create dummy IPlayers
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <param name="name">Name of the player</param>
        /// <param name="ip">IP of the player</param>
        /// <returns></returns>
        public static IPlayer CreateDummyPlayer(string id, string name, string ip) => new DiscordDummyPlayer(id, name, ip);
    }
}