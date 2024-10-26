using System;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Builders
{
    /// <summary>
    /// Formatter for player names
    /// </summary>
    public class PlayerNameFormatter
    {
        private readonly PlayerDisplayNameMode _mode;
        private readonly Func<IPlayer, string> _customNameFunc;

        /// <summary>
        /// Default Player Name Formatter
        /// </summary>
        public static readonly PlayerNameFormatter Default = Create(PlayerDisplayNameMode.Default);
        
        /// <summary>
        /// Include clan name in the player name
        /// </summary>
        public static readonly PlayerNameFormatter ClanName = Create(PlayerDisplayNameMode.Clan);
        
        /// <summary>
        /// Include Player ID in the player name
        /// </summary>
        public static readonly PlayerNameFormatter PlayerId = Create(PlayerDisplayNameMode.PlayerId);

        /// <summary>
        /// Include all name options in the player name
        /// </summary>
        public static readonly PlayerNameFormatter All = Create(PlayerDisplayNameMode.All);

        private PlayerNameFormatter(PlayerDisplayNameMode mode, Func<IPlayer, string> customNameFunc)
        {
            _mode = mode;
            _customNameFunc = customNameFunc;
        }

        /// <summary>
        /// Create a new Player Name formatter with the given <see cref="PlayerDisplayNameMode"/>
        /// </summary>
        /// <param name="mode">Mode to use for Player Display Name</param>
        /// <returns>A new <see cref="PlayerNameFormatter"/></returns>
        private static PlayerNameFormatter Create(PlayerDisplayNameMode mode) => new(mode, null);
        
        /// <summary>
        /// Create a new Player Name formatter with the given Custom Name Function
        /// </summary>
        /// <param name="customNameFunc">Function to use for formatting the name</param>
        /// <returns>A new <see cref="PlayerNameFormatter"/></returns>
        public static PlayerNameFormatter Create(Func<IPlayer, string> customNameFunc) => new(PlayerDisplayNameMode.Default, customNameFunc);

        /// <summary>
        /// Formats the player name
        /// </summary>
        /// <param name="player">Player to have their name formatted</param>
        /// <returns>Formatted player name</returns>
        public string Format(IPlayer player) => _customNameFunc != null ? _customNameFunc(player) : DiscordExtensionCore.Instance.GetPlayerName(player, _mode);
    }
}