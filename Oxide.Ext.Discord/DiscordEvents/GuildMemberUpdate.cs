using System.Collections.Generic;
using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class GuildMemberUpdate
    {
        public string guild_id { get; set; }

        public List<string> roles { get; set; }

        public User user { get; set; }

        public string nick { get; set; }
    }
}
