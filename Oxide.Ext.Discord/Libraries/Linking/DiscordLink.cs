using System;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Constants;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a library for discord linking
    /// </summary>
    public class DiscordLink : BaseDiscordLibrary<DiscordLink>, IDebugLoggable
    {
        /// <summary>
        /// Readonly Dictionary of Player ID's to Discord ID's
        /// </summary>
        public readonly IReadOnlyDictionary<PlayerId, Snowflake> PlayerToDiscordIds;
        
        /// <summary>
        /// Readonly Dictionary of Discord ID's to Player ID's
        /// </summary>
        public readonly IReadOnlyDictionary<Snowflake, PlayerId> DiscordToPlayerIds;
        
        /// <summary>
        /// Readonly Collection of all Player ID's
        /// </summary>
        public readonly ICollection<PlayerId> PlayerIds;
        
        /// <summary>
        /// Readonly Collection of all Discord ID's
        /// </summary>
        public readonly ICollection<Snowflake> DiscordIds;

        /// <summary>
        /// Returns if there is a registered link plugin
        /// </summary>
        /// <returns></returns>
        public bool IsEnabled => _linkPlugins.Count != 0;
        
        /// <summary>
        /// Returns the number of linked players
        /// </summary>
        /// <returns></returns>
        public int LinkedCount => _links.Count;
        
        private readonly BidirectionalDictionary<PlayerId, Snowflake> _links = new();
        private readonly Hash<PluginId, IDictionary<PlayerId, Snowflake>> _linkPlugins = new();

        private readonly ILogger _logger;

        /// <summary>
        /// DiscordLink Constructor
        /// </summary>
        /// <param name="logger">Logger for Discord Link</param>
        internal DiscordLink(ILogger logger)
        {
            _logger = logger;
            PlayerToDiscordIds = _links.AsReadOnlyKeyToValue();
            DiscordToPlayerIds = _links.AsReadOnlyValueToKey();
            PlayerIds = _links.AsKeyCollection();
            DiscordIds = _links.AsValueCollection();
        }
        
        /// <summary>
        /// Adds a link plugin to be the plugin used with the Discord Link library
        /// </summary>
        /// <param name="link"></param>
        public void AddLinkPlugin(IDiscordLink link)
        {
            if (link == null) throw new ArgumentNullException(nameof(link));

            IDictionary<PlayerId, Snowflake> data = link.GetPlayerIdToDiscordIds();
            if (data == null)
            {
                _logger.Error($"{{0}} returned null when {nameof(link.GetPlayerIdToDiscordIds)} was called", link.Name);
                return;
            }
            
            _linkPlugins[link.Id()] = data;

            foreach (KeyValuePair<PlayerId,Snowflake> pair in data)
            {
                AddLink(pair.Key, pair.Value);
            }
            
            _logger.Debug("{0} has been registered as a DiscordLink plugin", link.Name);
        }

        /// <summary>
        /// Removes a link plugin from the Discord Link library
        /// </summary>
        /// <param name="plugin"></param>
        public void RemoveLinkPlugin(IDiscordLink plugin)
        {
            if (plugin == null) throw new ArgumentNullException(nameof(plugin));

            PluginId pluginId = plugin.Id();
            IDictionary<PlayerId, Snowflake> pluginData = _linkPlugins[pluginId];
            if (pluginData == null)
            {
                return;
            }
            
            _linkPlugins.Remove(pluginId);
            foreach (KeyValuePair<PlayerId, Snowflake> link in pluginData)
            {
                bool keepLink = false;
                foreach (IDictionary<PlayerId, Snowflake> links in _linkPlugins.Values)
                {
                    if (links.ContainsKey(link.Key))
                    {
                        keepLink = true;
                        break;
                    }
                }

                if (!keepLink)
                {
                    RemoveLink(link.Key, link.Value);
                }
            }
        }

        ///<inheritdoc/>
        protected override void OnPluginUnloaded(Plugin plugin)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (plugin is IDiscordLink link)
            {
                RemoveLinkPlugin(link);
            }
        }

        /// <summary>
        /// Returns if the specified ID is linked
        /// </summary>
        /// <param name="playerId">Player ID of the player</param>
        /// <returns>True if the ID is linked; false otherwise</returns>
        public bool IsLinked(string playerId) => IsLinked(new PlayerId(playerId));
        
        /// <summary>
        /// Returns if the specified ID is linked
        /// </summary>
        /// <param name="playerId">Player ID of the player</param>
        /// <returns>True if the ID is linked; false otherwise</returns>
        public bool IsLinked(PlayerId playerId) => _links.ContainsKey(playerId);

        /// <summary>
        /// Returns if the specified ID is linked
        /// </summary>
        /// <param name="discordId">Discord ID of the player</param>
        /// <returns>True if the ID is linked; false otherwise</returns>
        public bool IsLinked(Snowflake discordId) => _links.ContainsKey(discordId);

        /// <summary>
        /// Returns if the specified ID is linked
        /// </summary>
        /// <param name="player">Player to check if linked</param>
        /// <returns>True if the player is linked; false otherwise</returns>
        public bool IsLinked(IPlayer player) => IsLinked(player.Id);

        /// <summary>
        /// Returns if the specified ID is linked
        /// </summary>
        /// <param name="user">Discord user to check</param>
        /// <returns>True if the user is linked; false otherwise</returns>
        public bool IsLinked(DiscordUser user) => IsLinked(user.Id);

        /// <summary>
        /// Returns the Player ID of the given Discord ID if there is a link
        /// </summary>
        /// <param name="discordId">Discord ID to get player ID for</param>
        /// <returns>Player ID of the given discord ID if linked; null otherwise</returns>
        public PlayerId GetPlayerId(Snowflake discordId) => _links.TryGetValue(discordId, out PlayerId playerId) ? playerId : default;

        /// <summary>
        /// Returns the Player ID of the given Discord ID if there is a link
        /// </summary>
        /// <param name="user"><see cref="DiscordUser"/> to get player ID for</param>
        /// <returns>Player ID of the given discord ID if linked; null otherwise</returns>
        public PlayerId GetPlayerId(DiscordUser user) => GetPlayerId(user.Id);

        /// <summary>
        /// Returns the IPlayer for the given Discord ID
        /// </summary>
        /// <param name="discordId">Discord ID to get IPlayer for</param>
        /// <returns>IPlayer for the given Discord ID; null otherwise</returns>
        public IPlayer GetPlayer(Snowflake discordId) => _links.TryGetValue(discordId, out PlayerId playerId) ? ServerPlayerCache.Instance.GetPlayerById(playerId.Id) : null;

        /// <summary>
        /// Returns the Discord ID for the given Player ID
        /// </summary>
        /// <param name="playerId">Player ID to get Discord ID for</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public Snowflake GetDiscordId(string playerId) => GetDiscordId(new PlayerId(playerId));
        
        /// <summary>
        /// Returns the Discord ID for the given Player ID
        /// </summary>
        /// <param name="playerId">Player ID to get Discord ID for</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public Snowflake GetDiscordId(PlayerId playerId) => _links.TryGetValue(playerId, out Snowflake id) ? id : default;

        /// <summary>
        /// Returns the Discord ID for the given IPlayer
        /// </summary>
        /// <param name="player">Player to get Discord ID for</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public Snowflake GetDiscordId(IPlayer player) => GetDiscordId(player.Id);

        /// <summary>
        /// Returns a minimal Discord User
        /// </summary>
        /// <param name="playerId">ID of the in game player</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public DiscordUser GetDiscordUser(string playerId) => GetDiscordUser(new PlayerId(playerId));
        
        /// <summary>
        /// Returns a minimal Discord User
        /// </summary>
        /// <param name="playerId">ID of the in game player</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public DiscordUser GetDiscordUser(PlayerId playerId) => _links.TryGetValue(playerId, out Snowflake discordId) && discordId.IsValid() ? EntityCache<DiscordUser>.Instance.GetOrCreate(discordId) : null;

        /// <summary>
        /// Returns a minimal Discord User
        /// </summary>
        /// <param name="player">Player to get the Discord User for</param>
        /// <returns>Discord ID for the given IPlayer; null otherwise</returns>
        public DiscordUser GetDiscordUser(IPlayer player) => GetDiscordUser(player.Id);

        /// <summary>
        /// Returns a linked guild member for the matching player id in the given guild
        /// </summary>
        /// <param name="playerId">ID of the in game player</param>
        /// <param name="guild">Guild the member is in</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public GuildMember GetLinkedMember(string playerId, DiscordGuild guild) => GetLinkedMember(new PlayerId(playerId), guild);

        /// <summary>
        /// Returns a linked guild member for the matching player id in the given guild
        /// </summary>
        /// <param name="playerId">ID of the in game player</param>
        /// <param name="guild">Guild the member is in</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public GuildMember GetLinkedMember(PlayerId playerId, DiscordGuild guild)
        {
            if (guild == null) throw new ArgumentNullException(nameof(guild));
            Snowflake discordId = GetDiscordId(playerId);
            if (!discordId.IsValid() || !guild.IsAvailable)
            {
                return null;
            }

            return guild.Members[discordId];
        }

        /// <summary>
        /// Returns a linked guild member for the matching <see cref="IPlayer"/> in the given guild
        /// </summary>
        /// <param name="player">Player to get the Discord User for</param>
        /// <param name="guild">Guild the member is in</param>
        /// <returns>Discord ID for the given Player ID; null otherwise</returns>
        public GuildMember GetLinkedMember(IPlayer player, DiscordGuild guild) => GetLinkedMember(player.Id, guild);
        

        /// <summary>
        /// Called by a link plugin when a link occured
        /// </summary>
        /// <param name="plugin">Plugin that initiated the link</param>
        /// <param name="player">Player being linked</param>
        /// <param name="discord">DiscordUser being linked</param>
        public void OnLinked(Plugin plugin, IPlayer player, DiscordUser discord)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (discord == null) throw new ArgumentNullException(nameof(discord));

            if (!IsValidLinkPlugin(plugin))
            {
                return;
            }
            
            _linkPlugins[plugin.Id()][player.PlayerId()] = discord.Id;
            AddLink(new PlayerId(player.Id), discord.Id);
            
            DiscordHook.CallGlobalHook(DiscordExtHooks.OnDiscordPlayerLinked, player, discord);
        }

        /// <summary>
        /// Called by a link plugin when an unlink has occured
        /// </summary>
        /// <param name="plugin">Plugin that is unlinking</param>
        /// <param name="player">Player being unlinked</param>
        /// <param name="discord">DiscordUser being unlinked</param>
        public void OnUnlinked(Plugin plugin, IPlayer player, DiscordUser discord)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (discord == null) throw new ArgumentNullException(nameof(discord));
            
            if (!IsValidLinkPlugin(plugin))
            {
                return;
            }
            
            DiscordHook.CallGlobalHook(DiscordExtHooks.OnDiscordPlayerUnlink, player, discord);
            RemoveLink(new PlayerId(player.Id), discord.Id);
            _linkPlugins[plugin.Id()].Remove(player.PlayerId());
            DiscordHook.CallGlobalHook(DiscordExtHooks.OnDiscordPlayerUnlinked, player, discord);
        }
        
        private void AddLink(PlayerId playerId, Snowflake discordId)
        {
            _links[playerId] = discordId;
        }
        
        private void RemoveLink(PlayerId playerId, Snowflake discordId)
        {
            _links.Remove(playerId);
            _links.Remove(discordId);
        }
        
        private bool IsValidLinkPlugin(Plugin plugin)
        {
            // ReSharper disable once SuspiciousTypeConversion.Global
            if (plugin is not IDiscordLink link)
            {
                _logger.Error($"{plugin.Name} tried to link but is not registered as a link plugin");
                return false;
            }

            if (!_linkPlugins.ContainsKey(link.Id()))
            {
                _logger.Error($"{plugin.Name} has not been added as a link plugin and cannot set a link");
                return false;
            }
            
            return true;
        }

        ///<inheritdoc/>
        public void LogDebug(DebugLogger logger)
        {
            logger.AppendField("Total Links", _links.Count);
            logger.AppendList("Plugins", _linkPlugins.Keys);
        }
    }
}