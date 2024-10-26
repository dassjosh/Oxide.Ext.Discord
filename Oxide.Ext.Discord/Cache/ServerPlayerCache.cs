using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Plugins;
using Oxide.Ext.Discord.Services;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Cache for server <see cref="IPlayer"/>
    /// </summary>
    public sealed class ServerPlayerCache : Singleton<ServerPlayerCache>
    {
        private readonly ConcurrentDictionary<string, IPlayer> _dummyPlayerCache = new();
        private readonly Func<string, IPlayer> _valueFactory = id => new DiscordDummyPlayer(id);
        private IPlayerSearchService _search;

        private static readonly IPlayerManager Players = OxideLibrary.Instance.Covalence.Players;

        private ServerPlayerCache() { }

        /// <summary>
        /// Returns the <see cref="IPlayer"/> for the given ID
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns><see cref="IPlayer"/></returns>
        public IPlayer GetPlayerById(string id) => Players.FindPlayerById(id) ?? _dummyPlayerCache.GetOrAdd(id, _valueFactory);

        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> matching player names that are online
        /// </summary>
        /// <param name="name">Name to match on</param>
        /// <returns></returns>
        public IEnumerable<IPlayer> GetOnlinePlayers(string name) => _search.GetOnlinePlayers(name);
        
        /// <summary>
        /// Returns an <see cref="IEnumerable{T}"/> matching player names
        /// </summary>
        /// <param name="name">Name to match on</param>
        /// <returns></returns>
        public IEnumerable<IPlayer> GetAllPlayers(string name) => _search.GetAllPlayers(name);

        internal void SetSearchService()
        {
            if (DiscordConfig.Instance.Search.EnablePlayerNameSearchTrie)
            {
                _search = new UkkonenTrieService();
            }
            else
            {
                _search = new CovalenceSearchService();
            }
        }

        internal void OnUserConnected(IPlayer player)
        {
            _search.OnUserConnected(player);
        }

        internal void OnUserDisconnected(IPlayer player) => _search.OnUserDisconnected(player);
        internal void OnUserNameUpdated(IPlayer player, string oldName, string newName) => _search.OnUserNameUpdated(player, oldName, newName);
    }
}