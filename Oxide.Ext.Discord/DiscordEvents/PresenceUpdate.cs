using System.Collections.Generic;
using uMod.Ext.Discord.DiscordObjects;

namespace uMod.Ext.Discord.DiscordEvents
{
    public class PresenceUpdate
    {
        public User user { get; set; }

        public List<string> roles { get; set; }

        public Game game { get; set; }

        public string guild_id { get; set; }

        public string status { get; set; }
    }
}
