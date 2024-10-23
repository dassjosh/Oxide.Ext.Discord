﻿using System;
using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Cache;

namespace Oxide.Ext.Discord.Services
{
    internal class CovalenceSearchService : IPlayerSearchService
    {
        public IEnumerable<IPlayer> GetOnlinePlayers(string name)
        {
            foreach (IPlayer player in OxideLibrary.Instance.Covalence.Players.Connected)
            {
                if (IsMatch(player, name))
                {
                    yield return player;
                }
            }
        }

        public IEnumerable<IPlayer> GetAllPlayers(string name)
        {
            foreach (IPlayer player in OxideLibrary.Instance.Covalence.Players.All)
            {
                if (IsMatch(player, name))
                {
                    yield return player;
                }
            }
        }
        
        private static bool IsMatch(IPlayer player, string name) => !string.IsNullOrWhiteSpace(name) && player.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) != -1;

        public void OnUserConnected(IPlayer player) { }

        public void OnUserDisconnected(IPlayer player) { }

        public void OnUserNameUpdated(IPlayer player, string oldName, string newName) {}
    }
}