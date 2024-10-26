using Oxide.Core.Libraries.Covalence;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Placeholder Keys for <see cref="IServer"/>
    /// </summary>
    public class ServerKeys
    {
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Name"/>
        /// </summary>
        public readonly PlaceholderKey Name;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Players"/>
        /// </summary>
        public readonly PlaceholderKey Players;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.MaxPlayers"/>
        /// </summary>
        public readonly PlaceholderKey MaxPlayers;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for Total Players
        /// </summary>
        public readonly PlaceholderKey TotalPlayers;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Version"/>
        /// </summary>
        public readonly PlaceholderKey Version;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Protocol"/>
        /// </summary>
        public readonly PlaceholderKey Protocol;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Address"/>
        /// </summary>
        public readonly PlaceholderKey Address;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Port"/>
        /// </summary>
        public readonly PlaceholderKey Port;
        
        /// <summary>
        /// <see cref="PlaceholderKey"/> for <see cref="IServer.Time"/>
        /// </summary>
        public readonly PlaceholderKey Time;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix">Placeholder Key Prefix</param>
        public ServerKeys(string prefix)
        {
            Name = new PlaceholderKey(prefix, "name");
            Players = new PlaceholderKey(prefix, "players");
            MaxPlayers = new PlaceholderKey(prefix, "players.max");
            TotalPlayers = new PlaceholderKey(prefix, "players.total");
            Version = new PlaceholderKey(prefix, "version");
            Protocol = new PlaceholderKey(prefix, "protocol");
            Address = new PlaceholderKey(prefix, "address");
            Port = new PlaceholderKey(prefix, "port");
            Time = new PlaceholderKey(prefix, "time");
        }
    }
}