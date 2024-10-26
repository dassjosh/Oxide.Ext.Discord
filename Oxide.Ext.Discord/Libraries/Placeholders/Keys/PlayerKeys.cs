using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Extensions;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="IPlayer"/>
    /// </summary>
    public class PlayerKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Id"/>
        /// </summary>
        public readonly PlaceholderKey Id;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Name"/> with clan formatting
        /// </summary>
        public readonly PlaceholderKey NameClan;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Name"/> with Player ID formatting
        /// </summary>
        public readonly PlaceholderKey NamePlayerId;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Name"/> with clan and player ID formatting.
        /// </summary>
        public readonly PlaceholderKey NameAll;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.IsConnected"/>
        /// </summary>
        public readonly PlaceholderKey Connected;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> permissions
        /// </summary>
        public readonly PlaceholderKey Permissions;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> groups
        /// </summary>
        public readonly PlaceholderKey Groups;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Health"/>
        /// </summary>
        public readonly PlaceholderKey Health;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.MaxHealth"/>
        /// </summary>
        public readonly PlaceholderKey MaxHealth;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Position()"/>
        /// </summary>
        public readonly PlaceholderKey Position;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Ping"/>
        /// </summary>
        public readonly PlaceholderKey Ping;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer.Address"/>
        /// </summary>
        public readonly PlaceholderKey Address;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Country
        /// Requires Placeholder API plugin in order to use
        /// </summary>
        public readonly PlaceholderKey Country;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Country Code
        /// Requires Placeholder API plugin in order to use
        /// </summary>
        public readonly PlaceholderKey CountryCode;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Country Emoji
        /// Requires Placeholder API plugin in order to use
        /// </summary>
        public readonly PlaceholderKey CountryEmoji;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Clan Tag
        /// Requires Clans plugin in order to use
        /// </summary>
        public readonly PlaceholderKey ClanTag;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Steam Profile
        /// </summary>
        public readonly PlaceholderKey SteamProfile;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Steam Avatar Image Url
        /// </summary>
        public readonly PlaceholderKey SteamAvatar;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> BattleMetrics search by player id Url
        /// </summary>
        public readonly PlaceholderKey BattleMetricsPlayerId;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> BattleMetrics search by player name Url
        /// </summary>
        public readonly PlaceholderKey BattleMetricsName;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IPlayer"/> Server Armor Profile Url
        /// </summary>
        public readonly PlaceholderKey ServerArmorProfile;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="PlayerExt.IsLinked"/>
        /// </summary>
        public readonly PlaceholderKey IsLinked;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public PlayerKeys(string prefix)
        {
            Id = new PlaceholderKey(prefix, "id");
            Name = new PlaceholderKey(prefix, "name");
            NameClan = new PlaceholderKey(prefix, "name", "clan");
            NamePlayerId = new PlaceholderKey(prefix, "name", "playerid");
            NameAll = new PlaceholderKey(prefix, "name", "all");
            Connected = new PlaceholderKey(prefix, "connected");
            Permissions = new PlaceholderKey(prefix, "permissions");
            Groups = new PlaceholderKey(prefix, "groups");
            Health = new PlaceholderKey(prefix, "health");
            MaxHealth = new PlaceholderKey(prefix, "health.max");
            Position = new PlaceholderKey(prefix, "position");
            Ping = new PlaceholderKey(prefix, "ping");
            Address = new PlaceholderKey(prefix, "address");
            Country = new PlaceholderKey(prefix, "country");
            CountryCode = new PlaceholderKey(prefix, "country.code");
            CountryEmoji = new PlaceholderKey(prefix, "country.emoji");
            ClanTag = new PlaceholderKey(prefix, "clan.tag");
            SteamProfile = new PlaceholderKey(prefix, "steam.profile");
            SteamAvatar = new PlaceholderKey(prefix, "steam.avatar");
            BattleMetricsPlayerId = new PlaceholderKey(prefix, "battlemetrics.steamid");
            BattleMetricsName = new PlaceholderKey(prefix, "battlemetrics.name");
            ServerArmorProfile = new PlaceholderKey(prefix, "serverarmor.profile");
            IsLinked = new PlaceholderKey(prefix, "islinked");
        }
    }
}