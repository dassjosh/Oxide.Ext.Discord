using System;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Builders;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="IPlayer"/> placeholders
    /// </summary>
    public static class PlayerPlaceholders
    {
        internal static readonly PlaceholderDataKey TargetPlayerKey = new("TargetPlayer");
        
        /// <summary>
        /// <see cref="IPlayer.Id"/> placeholder
        /// </summary>
        public static string Id(IPlayer player) => player.Id;
        
        /// <summary>
        /// <see cref="IPlayer.Name"/> placeholder
        /// </summary>
        public static string Name(PlaceholderState state, IPlayer player)
        {
            string format = state.Format;
            if (string.IsNullOrEmpty(format) || !Enum.TryParse(format, true, out PlayerDisplayNameMode mode))
            {
                return player.Name;
            }

            return mode switch
            {
                PlayerDisplayNameMode.Clan => PlayerNameFormatter.ClanName.Format(player),
                PlayerDisplayNameMode.PlayerId => PlayerNameFormatter.PlayerId.Format(player),
                PlayerDisplayNameMode.All => PlayerNameFormatter.All.Format(player),
                _ => PlayerNameFormatter.Default.Format(player)
            };
        }

        /// <summary>
        /// <see cref="IPlayer.IsConnected"/> placeholder
        /// </summary>
        public static bool Connected(IPlayer player) => player.IsConnected;
        
        /// <summary>
        /// <see cref="IPlayer.Health"/> placeholder
        /// </summary>
        public static float Health(IPlayer player) => player.Object != null ? player.Health : 0;
        
        /// <summary>
        /// <see cref="IPlayer.MaxHealth"/> placeholder
        /// </summary>
        public static float MaxHealth(IPlayer player) => player.Object != null ? player.MaxHealth : 0;
        
        /// <summary>
        /// <see cref="IPlayer.Position()"/> placeholder
        /// </summary>
        public static GenericPosition Position(IPlayer player) => player.Object != null ? player.Position() : new GenericPosition();
        
        /// <summary>
        /// <see cref="IPlayer.Ping"/> placeholder
        /// </summary>
        public static int Ping(IPlayer player) => player.Ping;
        
        /// <summary>
        /// Player Permissions Placeholder
        /// </summary>
        public static string[] Permissions(IPlayer player) => OxideLibrary.Instance.Permission.GetUserPermissions(player.Id);
        
        /// <summary>
        /// Player Groups Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string[] Groups(IPlayer player) => OxideLibrary.Instance.Permission.GetUserGroups(player.Id);

        /// <summary>
        /// Player Address Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string Address(IPlayer player) => player.Address;

        /// <summary>
        /// Player Country Name Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string CountryName(IPlayer player) => IpPlaceholders.CountryName(player.Address);

        /// <summary>
        /// Player Country Name Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string CountryCode(IPlayer player) => IpPlaceholders.CountryCode(player.Address);

        /// <summary>
        /// Player Flag Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string CountryEmoji(IPlayer player) => IpPlaceholders.CountryEmoji(player.Address);

        /// <summary>
        /// Player Groups Placeholder
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static string ClanTag(IPlayer player) => DiscordExtensionCore.Instance.GetClanTag(player);

        /// <summary>
        /// Steam Profile Url Placeholder 
        /// </summary>
        public static string SteamProfileUrl(IPlayer player) => $"https://steamcommunity.com/profiles/{player.Id}";

        /// <summary>
        /// Steam Avatar Url Placeholder
        /// </summary>
        public static string SteamAvatarUrl(IPlayer player) => DiscordExtensionCore.Instance.GetPlayerAvatarUrl(player.Id);

        /// <summary>
        /// Battle metrics Steam ID Url Placeholder
        /// </summary>
        public static string BattleMetricsSteamIdUrl(IPlayer player) => $"https://www.battlemetrics.com/rcon/players?filter[search]={player.Id}";
        
        /// <summary>
        /// Battle metrics Place Name Url Placeholder
        /// </summary>
        public static string BattleMetricsNameUrl(IPlayer player) => $"https://www.battlemetrics.com/rcon/players?filter[search]={player.Name}";        
        /// <summary>
        /// Battle metrics Place Name Url Placeholder
        /// </summary>
        public static string ServerArmorUrl(IPlayer player) => $"https://io.serverarmour.com/profile/{player.Id}";
        
        /// <summary>
        /// <see cref="PlayerExt.IsLinked"/> placeholder
        /// </summary>
        public static bool IsLinked(PlaceholderState state, IPlayer player) => player.IsLinked();

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Player, new PlaceholderDataKey(nameof(IPlayer)));
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.PlayerTarget, TargetPlayerKey);
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, PlayerKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.Id, dataKey, Id);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<IPlayer, bool>(plugin, keys.Connected, dataKey, Connected);
            placeholders.RegisterPlaceholder<IPlayer, string[]>(plugin, keys.Permissions, dataKey, Permissions);
            placeholders.RegisterPlaceholder<IPlayer, string[]>(plugin, keys.Groups, dataKey, Groups);
            placeholders.RegisterPlaceholder<IPlayer, float>(plugin, keys.Health, dataKey, Health);
            placeholders.RegisterPlaceholder<IPlayer, float>(plugin, keys.MaxHealth, dataKey, MaxHealth);
            placeholders.RegisterPlaceholder<IPlayer, GenericPosition>(plugin, keys.Position, dataKey, Position);
            placeholders.RegisterPlaceholder<IPlayer, int>(plugin, keys.Ping, dataKey, Ping);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.Address, dataKey, CountryName);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.Country, dataKey, CountryCode);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.CountryEmoji, dataKey, CountryEmoji);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.ClanTag, dataKey, ClanTag);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.SteamProfile, dataKey, SteamProfileUrl);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.SteamAvatar, dataKey, SteamAvatarUrl);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.BattleMetricsPlayerId, dataKey, BattleMetricsSteamIdUrl);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.BattleMetricsName, dataKey, BattleMetricsNameUrl);
            placeholders.RegisterPlaceholder<IPlayer, string>(plugin, keys.ServerArmorProfile, dataKey, ServerArmorUrl);
            placeholders.RegisterPlaceholder<IPlayer, bool>(plugin, keys.IsLinked, dataKey, IsLinked);
        }
    }
}