using System;
using Oxide.Core.Libraries.Covalence;
using Oxide.Ext.Discord.Cache;

namespace Oxide.Ext.Discord.Libraries
{
    /// <summary>
    /// Represents a <see cref="DiscordLink"/> Player ID
    /// </summary>
    public readonly struct PlayerId : IEquatable<PlayerId>
    {
        /// <summary>
        /// ID of the player
        /// </summary>
        public readonly string Id;
        
        /// <summary>
        /// Returns true if the ID is valid; false otherwise
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Id);
        
        /// <summary>
        /// Returns the IPlayer for the Player ID
        /// </summary>
        public IPlayer Player => IsValid ? ServerPlayerCache.Instance.GetPlayerById(Id) : null;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <exception cref="ArgumentNullException">Thrown if ID is null</exception>
        public PlayerId(string id)
        {
            Id = !string.IsNullOrEmpty(id) ? id : throw new ArgumentNullException(nameof(id));
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player">IPlayer for the ID</param>
        /// <exception cref="ArgumentNullException">Thrown if the IPlayer is null</exception>
        public PlayerId(IPlayer player)
        {
            Id = player?.Id ?? throw new ArgumentNullException(nameof(player));
        }

        /// <inheritdoc />
        public bool Equals(PlayerId other) => Id == other.Id;
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is PlayerId other && Equals(other);
        /// <inheritdoc />
        public override int GetHashCode() => (Id != null ? Id.GetHashCode() : 0);
    }
}