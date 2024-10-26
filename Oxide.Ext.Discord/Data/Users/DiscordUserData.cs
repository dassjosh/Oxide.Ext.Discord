using System.Collections.Generic;
using Oxide.Ext.Discord.Entities;
using ProtoBuf;

namespace Oxide.Ext.Discord.Data
{
    [ProtoContract]
    internal sealed class DiscordUserData : BaseDataFile<DiscordUserData>
    {
        [ProtoMember(1)]
        private Dictionary<Snowflake, BotData> _bots = new();

        public bool TryGetBotData(Snowflake id, out BotData data) => _bots.TryGetValue(id, out data);
        
        public BotData GetBotData(Snowflake botId)
        {
            if (!_bots.TryGetValue(botId, out BotData data))
            {
                data = new BotData();
                _bots[botId] = data;
                OnDataChanged();
            }

            return data;
        }
    }
}