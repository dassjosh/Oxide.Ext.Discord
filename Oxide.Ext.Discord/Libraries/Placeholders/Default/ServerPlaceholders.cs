using System;
using System.Linq;
using System.Net;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Plugins;
using Oxide.Ext.Discord.Cache;
using Oxide.Ext.Discord.Plugins;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// <see cref="IServer"/> placeholders
    /// </summary>
    public static class ServerPlaceholders
    {
        /// <summary>
        /// <see cref="IServer.Name"/> placeholder
        /// </summary>
        public static string Name(IServer server) => server.Name;
        
        /// <summary>
        /// <see cref="IServer.Players"/> placeholder
        /// </summary>
        public static int Players(IServer server) => server.Players;
        
        /// <summary>
        /// <see cref="IServer.MaxPlayers"/> placeholder
        /// </summary>
        public static int MaxPlayers(IServer server) => server.MaxPlayers;
        
        /// <summary>
        /// <see cref="IServer.MaxPlayers"/> placeholder
        /// </summary>
        public static int TotalPlayers(IServer server) => OxideLibrary.Instance.Covalence.Players.All.Count();

        /// <summary>
        /// <see cref="IServer.Version"/> placeholder
        /// </summary>
        public static string Version(IServer server) => server.Version;
        
        /// <summary>
        /// <see cref="IServer.Protocol"/> placeholder
        /// </summary>
        public static string Protocol(IServer server) => server.Protocol;

        /// <summary>
        /// <see cref="IServer.Address"/> placeholder
        /// </summary>
        public static IPAddress Address(IServer server) => server.Address;
        
        /// <summary>
        /// <see cref="IServer.Port"/> placeholder
        /// </summary>
        public static ushort Port(IServer server) => server.Port;
        
        /// <summary>
        /// <see cref="IServer.Time"/> placeholder
        /// </summary>
        public static DateTime Time(IServer server) => server.Time;

        internal static void RegisterPlaceholders()
        {
            RegisterPlaceholders(DiscordExtensionCore.Instance, DefaultKeys.Server, new PlaceholderDataKey(nameof(IServer)));
        }
        
        /// <summary>
        /// Registers placeholders for the given plugin. 
        /// </summary>
        /// <param name="plugin">Plugin to register placeholders for</param>
        /// <param name="keys">Prefix to use for the placeholders</param>
        /// <param name="dataKey">Data key in <see cref="PlaceholderData"/></param>
        public static void RegisterPlaceholders(Plugin plugin, ServerKeys keys, PlaceholderDataKey dataKey)
        {
            DiscordPlaceholders placeholders = DiscordPlaceholders.Instance;
            placeholders.RegisterPlaceholder<IServer, string>(plugin, keys.Name, dataKey, Name);
            placeholders.RegisterPlaceholder<IServer, int>(plugin, keys.Players, dataKey, Players);
            placeholders.RegisterPlaceholder<IServer, int>(plugin, keys.MaxPlayers, dataKey, MaxPlayers);
            placeholders.RegisterPlaceholder<IServer, int>(plugin, keys.TotalPlayers, dataKey, TotalPlayers);
            placeholders.RegisterPlaceholder<IServer, string>(plugin, keys.Version, dataKey, Version);
            placeholders.RegisterPlaceholder<IServer, string>(plugin, keys.Protocol, dataKey, Protocol);
            placeholders.RegisterPlaceholder<IServer, IPAddress>(plugin, keys.Address, dataKey, Address);
            placeholders.RegisterPlaceholder<IServer, ushort>(plugin, keys.Port, dataKey, Port);
            placeholders.RegisterPlaceholder<IServer, DateTime>(plugin, keys.Time, dataKey, Time);
        }
    }
}