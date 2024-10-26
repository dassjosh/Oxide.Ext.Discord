using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Services
{
    internal class UkkonenTrieService : IPlayerSearchService
    {
        private readonly UkkonenTrie<IPlayer> _online = new(PlayerEquals);
        private readonly UkkonenTrie<IPlayer> _all = new(PlayerEquals);

        internal UkkonenTrieService()
        {
            foreach (IPlayer player in OxideLibrary.Instance.Covalence.Players.All)
            {
                _all.Add(player.Name, player);
            }
            
            foreach (IPlayer player in OxideLibrary.Instance.Covalence.Players.Connected)
            {
                _all.Add(player.Name, player);
            }
        }

        public IEnumerable<IPlayer> GetOnlinePlayers(string name) => _online.Search(name);

        public IEnumerable<IPlayer> GetAllPlayers(string name) => _all.Search(name);

        public void OnUserConnected(IPlayer player)
        {
            _all.Remove(player.Name, player);
            _online.Remove(player.Name, player);
            _all.Add(player.Name, player);
            _online.Add(player.Name, player);
        }

        public void OnUserDisconnected(IPlayer player) => _online.Remove(player.Name, player);

        public void OnUserNameUpdated(IPlayer player, string oldName, string newName)
        {
            _all.Remove(oldName, player);
            _all.Add(newName, player);
        }
        
        private static bool PlayerEquals(IPlayer left, IPlayer right) => left.Id == right.Id;
    }
}