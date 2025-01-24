using System;
using System.Linq;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Callbacks;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a channel subscription for a plugin
    /// </summary>
    public class DiscordChannelSubscription : IDebugLoggable
    {
        private readonly Snowflake _channelId;
        private readonly PluginId _pluginId;
        private readonly DiscordClient _client;
        private readonly Action<DiscordMessage> _callback;
        
        private Plugin _plugin;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="client">Discord Client for the subscription</param>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="callback">Callback when the channel message is sent</param>
        public DiscordChannelSubscription(DiscordClient client, Snowflake channelId, Action<DiscordMessage> callback)
        {
            _client = client;
            _plugin = client.Plugin;
            _channelId = channelId;
            _pluginId = _plugin.Id();
            _callback = callback;
        }

        /// <summary>
        /// Returns if a subscription can run.
        /// They can only run for the client that they were created for.
        /// </summary>
        /// <param name="client">Client to compare against</param>
        /// <returns>True if same bot client; false otherwise</returns>
        public bool CanRun(BotClient client)
        {
            return client != null && _client.Bot == client;
        }

        /// <summary>
        /// Returns if this subscription is for this plugin
        /// </summary>
        /// <param name="plugin">Plugin to check</param>
        /// <returns>True if the subscription is for this plugin; False otherwise</returns>
        public bool IsForPlugin(Plugin plugin) => plugin != null && plugin.Id() == _pluginId;

        /// <summary>
        /// Returns if this subscription is for the given channel
        /// </summary>
        /// <param name="channelId">Channel ID to check</param>
        /// <returns>True if the subscription is for this channel; False otherwise</returns>
        public bool IsForChannel(Snowflake channelId) => _channelId == channelId;

        /// <summary>
        /// Invokes the callback with the message
        /// </summary>
        /// <param name="message">Message that was sent in the given channel</param>
        public void Invoke(DiscordMessage message)
        {
            SubscriptionCallback.Start(_plugin, message, _callback);
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Plugin", _plugin.FullName());
            logger.AppendMethod("Method", _callback.Method);
            
            DiscordGuild guild = _client?.Bot.Servers.Values.FirstOrDefault(g => g.Channels.ContainsKey(_channelId));
            if (guild == null)
            {
                logger.AppendField("Guild", "Unknown Guild");
                return;
            }
            
            DiscordChannel channel = guild.Channels[_channelId];
            if (channel == null)
            {
                logger.AppendField("Channel", "Unknown Channel");
                return;
            }

            DiscordChannel parent = null;
            if (channel.ParentId.HasValue)
            {
                parent = guild.Channels[channel.ParentId.Value];
            }
            
            logger.AppendChannelPath("Path", guild, channel, parent);
            logger.AppendObject("Channel", channel);
        }

        internal void OnRemoved()
        {
            _plugin = null;
        }
    }
}