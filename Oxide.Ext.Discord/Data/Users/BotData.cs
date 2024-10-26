using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using ProtoBuf;

namespace Oxide.Ext.Discord.Data
{
    [ProtoContract]
    internal class BotData
    {
        [ProtoMember(1)]
        public Dictionary<Snowflake, UserData> Users { get; set; } = new();
        
        public UserData GetUserData(Snowflake userId)
        {
            if (!Users.TryGetValue(userId, out UserData data))
            {
                data = new UserData(userId);
                Users[userId] = data;
                DiscordUserData.Instance.OnDataChanged();
            }

            return data;
        }
    }
}