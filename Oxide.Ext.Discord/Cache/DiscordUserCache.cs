using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Oxide.Ext.Discord.Entities;
using Oxide.Ext.Discord.Entities.Users;
using Oxide.Ext.Discord.Singleton;

namespace Oxide.Ext.Discord.Cache
{
    /// <summary>
    /// <see cref="DiscordUser"/> Cache 
    /// </summary>
    public class DiscordUserCache : Singleton<DiscordUserCache>
    {
        private readonly ConcurrentDictionary<Snowflake, DiscordUser> _internalCache = new ConcurrentDictionary<Snowflake, DiscordUser>();
        
        /// <summary>
        /// Readonly Cache of <see cref="DiscordUser"/>
        /// </summary>
        public readonly IReadOnlyDictionary<Snowflake, DiscordUser> Cache;

        private DiscordUserCache()
        {
            Cache = new ReadOnlyDictionary<Snowflake, DiscordUser>(_internalCache);
        }
        
        /// <summary>
        /// Returns a cached <see cref="DiscordUser"/> for the given user ID or creates a new <see cref="DiscordUser"/> with that ID
        /// </summary>
        /// <param name="userId">User ID to lookup in the cache</param>
        /// <returns>Cached <see cref="DiscordUser"/></returns>
        public DiscordUser GetOrCreate(Snowflake userId)
        {
            if (!_internalCache.TryGetValue(userId, out DiscordUser user))
            {
                user = new DiscordUser
                {
                    Id = userId
                };
                _internalCache[userId] = user;
            }

            return user;
        }

        /// <summary>
        /// Returns a cached <see cref="DiscordUser"/> for the given user or returns the passed in DiscordUser that is now cached
        /// </summary>
        /// <param name="user">User to lookup in the cache</param>
        /// <returns>Cached <see cref="DiscordUser"/></returns>
        public DiscordUser GetOrCreate(IDiscordUser user)
        {
            if (!_internalCache.TryGetValue(user.Id, out DiscordUser existingUser))
            {
                if (user is DiscordUser)
                {
                    existingUser = (DiscordUser)user;
                }
                else
                {
                    existingUser = DiscordUser.FromInterface(user);
                }
                _internalCache[user.Id] = existingUser;
            }
            else
            {
                existingUser.Update(user);
            }

            return existingUser;
        }
    }
}