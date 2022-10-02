using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Oxide.Core;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// Cache for server <see cref="IPlayer"/>
    /// </summary>
    public class ServerPlayerCache
    {
        private static readonly ConcurrentDictionary<string, IPlayer> InternalCache = new ConcurrentDictionary<string, IPlayer>();
        
        /// <summary>
        /// Readonly Cache of <see cref="IPlayer"/>
        /// </summary>
        public static readonly IReadOnlyDictionary<string, IPlayer> Cache = new ReadOnlyDictionary<string, IPlayer>(InternalCache);

        private static readonly IPlayerManager Players = Interface.Oxide.GetLibrary<Covalence>().Players;

        /// <summary>
        /// Returns the <see cref="IPlayer"/> for the given ID
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns><see cref="IPlayer"/></returns>
        public static IPlayer GetPlayer(string id)
        {
            if (InternalCache.ContainsKey(id))
            {
                return InternalCache[id];
            }

            IPlayer player = Players.FindPlayerById(id);
            if (player == null)
            {
                player = new DiscordDummyPlayer(id);
            }

            InternalCache[id] = player;
            return player;
        }

        internal static void SetPlayer(IPlayer player)
        {
            
        }
    }
}