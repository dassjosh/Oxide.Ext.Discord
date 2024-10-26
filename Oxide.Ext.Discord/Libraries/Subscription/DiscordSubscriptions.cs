using System;
using System.Collections.Generic;
using Oxide.Core.Libraries;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Clients;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Exceptions;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{

    /// <summary>
    /// Represents Discord Subscriptions Oxide Library
    /// Allows for plugins to subscribe to discord channels
    /// </summary>
    public class DiscordSubscriptions : BaseDiscordLibrary<DiscordSubscriptions>, IDebugLoggable
    {
        private readonly Hash<Snowflake, List<DiscordChannelSubscription>> _subscriptions = new();

        private readonly ILogger _logger;

        /// <summary>
        /// DiscordSubscriptions Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        internal DiscordSubscriptions(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Returns if any subscriptions have been registered
        /// </summary>
        /// <returns>True if there are any subscriptions; False otherwise</returns>
        [LibraryFunction(nameof(HasSubscriptions))]
        public bool HasSubscriptions()
        {
            return _subscriptions.Count != 0;
        }

        /// <summary>
        /// Allows a plugin to add a subscription to a discord channel
        /// </summary>
        /// <param name="client">Client that is subscribing</param>
        /// <param name="channelId">Channel ID of the channel</param>
        /// <param name="message">Callback with the message that was created in the channel</param>
        /// <exception cref="ArgumentNullException">Exception if plugin or message is null</exception>
        /// <exception cref="ArgumentException">Exception if Channel ID is not valid</exception>
        [LibraryFunction(nameof(AddChannelSubscription))]
        public void AddChannelSubscription(DiscordClient client, Snowflake channelId, Action<DiscordMessage> message)
        {
            InvalidSnowflakeException.ThrowIfInvalid(channelId);
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (message == null) throw new ArgumentNullException(nameof(message));

            Plugin plugin = client.Plugin;
            _logger.Debug($"{nameof(DiscordSubscriptions)}.{nameof(AddChannelSubscription)} {{0}} added subscription to channel {{1}}", plugin.FullName(), channelId);

            List<DiscordChannelSubscription> subs = _subscriptions[channelId];
            if (subs == null)
            {
                subs = new List<DiscordChannelSubscription>();
                _subscriptions[channelId] = subs;
            }

            subs.RemoveAll(s => s.IsForPlugin(plugin));
            subs.Add(new DiscordChannelSubscription(client, channelId, message));
        }

        /// <summary>
        /// Removes a subscribed channel for a plugin
        /// </summary>
        /// <param name="plugin">Plugin to remove the subscription for</param>
        /// <param name="channelId">Channel ID to remove</param>
        /// <exception cref="ArgumentNullException">Exception if plugin is null</exception>
        /// <exception cref="ArgumentException">Exception if channel ID is not valid</exception>
        [LibraryFunction(nameof(RemoveChannelSubscription))]
        public void RemoveChannelSubscription(Plugin plugin, Snowflake channelId)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));
            InvalidSnowflakeException.ThrowIfInvalid(channelId);

            List<DiscordChannelSubscription> subs = _subscriptions[channelId];
            if (subs == null)
            {
                return;
            }

            subs.RemoveAll(s => s.IsForPlugin(plugin) && s.IsForChannel(channelId));
            _logger.Debug($"{nameof(DiscordSubscriptions)}.{nameof(RemoveChannelSubscription)} {{0}} removed subscription to channel {{1}}", plugin.Id(), channelId);
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            RemovePluginSubscriptions(plugin);
        }

        /// <summary>
        /// Remove all subscriptions for a plugin
        /// </summary>
        /// <param name="plugin">Plugin to remove subscriptions for</param>
        /// <exception cref="ArgumentNullException">Exception if plugin is null</exception>
        public void RemovePluginSubscriptions(Plugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));

            List<Snowflake> emptySubs = [];
            foreach (KeyValuePair<Snowflake, List<DiscordChannelSubscription>> hash in _subscriptions)
            {
                RemoveChannelSubscription(plugin, hash.Key);
                if (hash.Value.Count == 0)
                {
                    emptySubs.Add(hash.Key);
                }
            }

            if (emptySubs.Count != 0)
            {
                for (int i = 0; i < emptySubs.Count; i++)
                {
                    Snowflake emptySub = emptySubs[i];
                    _subscriptions.Remove(emptySub);
                }
            }

            _logger.Debug($"{nameof(DiscordSubscriptions)}.{nameof(RemovePluginSubscriptions)} Removed subscriptions for plugin {{0}}", plugin.FullName());
        }

        internal void HandleMessage(DiscordMessage message, DiscordChannel channel, BotClient client)
        {
            RunSubs(_subscriptions[message.ChannelId], message, client);

            if (channel.ParentId != null)
            {
                RunSubs(_subscriptions[channel.ParentId.Value], message, client);
            }
        }

        private void RunSubs(List<DiscordChannelSubscription> subs, DiscordMessage message, BotClient client)
        {
            if (subs == null)
            {
                return;
            }

            for (int index = 0; index < subs.Count; index++)
            {
                DiscordChannelSubscription sub = subs[index];
                if (sub.CanRun(client))
                {
                    sub.Invoke(message);
                }
            }
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendList("Subscriptions", GetSubscriptions());
        }

        private IEnumerable<DiscordChannelSubscription> GetSubscriptions()
        {
            foreach (List<DiscordChannelSubscription> pluginSubscriptions in _subscriptions.Values)
            {
                for (int index = 0; index < pluginSubscriptions.Count; index++)
                {
                    yield return pluginSubscriptions[index];
                }
            }
        }
    }
}