namespace uMod.Ext.Discord.DiscordObjects
{
    public class InviteCreated
    {
        public string channel_id { get; set; }

        public string code { get; set; }

        public string created_at { get; set; }

        public string guild_id { get; set; }

        public User inviter { get; set; }

        public int? max_age { get; set; }

        public int? max_uses { get; set; }

        public bool? temporary { get; set; }

        public int? uses { get; set; }
    }
}
