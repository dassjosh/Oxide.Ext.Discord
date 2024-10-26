using System.Collections.Generic;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Types;
using Oxide.Plugins;

namespace Oxide.Ext.Discord.Plugins
{
    internal partial class DiscordExtensionCore
    {
        private Plugin _clans;
        private readonly Hash<PlayerDisplayNameMode, Hash<string, string>> _playerNameCache = new();

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnClanCreate))]
        private void OnClanCreate()
        {
            ClearClanCache();
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnClanUpdate))]
        private void OnClanUpdate()
        {
            ClearClanCache();
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnClanDestroy))]
        private void OnClanDestroy()
        {
            ClearClanCache();
        }

        // ReSharper disable once UnusedMember.Local
        [HookMethod(nameof(OnUserNameUpdated))]
        private void OnUserNameUpdated(string playerId, string oldName, string newName)
        {
            if (oldName != newName)
            {
                foreach (KeyValuePair<PlayerDisplayNameMode, Hash<string, string>> cache in _playerNameCache)
                {
                    cache.Value.Remove(playerId);
                }
            }
        }

        private void ClearClanCache()
        {
            foreach (KeyValuePair<PlayerDisplayNameMode, Hash<string,string>> cache in _playerNameCache)
            {
                if (HasFlag(cache.Key, PlayerDisplayNameMode.Clan))
                {
                    cache.Value.Clear();
                }
            }
        }

        internal string GetClanTag(IPlayer player)
        {
            if (!IsPluginLoaded(_clans))
            {
                return string.Empty;
            }
            
            string tag = _clans.Call<string>("GetClanOf", player.Id);
            return !string.IsNullOrEmpty(tag) ? tag : string.Empty;
        }
        
        public string GetPlayerName(IPlayer player, PlayerDisplayNameMode options)
        {
            Hash<string, string> cache = _playerNameCache[options];
            if (cache == null)
            {
                cache = new Hash<string, string>();
                _playerNameCache[options] = cache;
            }
            
            string name = cache[player.Id];
            if (!string.IsNullOrEmpty(name))
            {
                return name;
            }

            ValueStringBuilder sb = new();
        
            if (_clans is {IsLoaded: true} && HasFlag(options, PlayerDisplayNameMode.Clan))
            {
                string clan = _clans.Call<string>("GetClanOf", player.Id);
                if (!string.IsNullOrEmpty(clan))
                {
                    sb.Append('[');
                    sb.Append(clan);
                    sb.Append("] ");
                }
            }

            sb.Append(player.Name);

            if (HasFlag(options, PlayerDisplayNameMode.PlayerId))
            {
                sb.Append(" (");
                sb.Append(player.Id);
                sb.Append(')');
            }

            name = sb.ToString();
            cache[player.Id] = name;
            return name;
        }
        
        private bool HasFlag(PlayerDisplayNameMode options, PlayerDisplayNameMode flag)
        {
            return (options & flag) == flag;
        }
    }
}