using System.Collections.Generic;
using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class GuildEmojisUpdate
    {
        public string guild_id { get; set; }

        public List<Emoji> emojis { get; set; }
    }
}
