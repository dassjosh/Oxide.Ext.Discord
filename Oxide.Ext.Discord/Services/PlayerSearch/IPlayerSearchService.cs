using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;

namespace Oxide.Ext.Discord.Services
{
    internal interface IPlayerSearchService
    {
        IEnumerable<IPlayer> GetOnlinePlayers(string name);
        IEnumerable<IPlayer> GetAllPlayers(string name);

        void OnUserConnected(IPlayer player);

        void OnUserDisconnected(IPlayer player);

        void OnUserNameUpdated(IPlayer player, string oldName, string newName);
    }
}