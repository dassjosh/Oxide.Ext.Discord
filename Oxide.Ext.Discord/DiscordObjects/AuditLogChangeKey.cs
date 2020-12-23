﻿namespace Oxide.Ext.Discord.DiscordObjects
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    //TODO: Fix Implementation
    public class AuditLogChangeKey
    {
        public string id { get; set; }

        public int? type { get; set; }
        
        public class Guild
        {
            public string name { get; set; }

            public string icon_hash { get; set; }

            public string splash_hash { get; set; }

            public string owner_id { get; set; }

            public string region { get; set; }

            public string afk_channel_id { get; set; }

            public int? afk_timeout { get; set; }

            public int? mfa_level { get; set; }

            public int? verification_level { get; set; }

            public int? explicit_content_filter { get; set; }

            public int? default_message_notifications { get; set; }

            public string vanity_url_code { get; set; }

            [JsonProperty(PropertyName = "$add")]
            public List<DiscordObjects.Role> add { get; set; }

            [JsonProperty(PropertyName = "$remove")]
            public List<DiscordObjects.Role> remove { get; set; }

            public int? prune_delete_days { get; set; }

            public bool widget_enabled { get; set; }

            public string widget_channel_id { get; set; }
            
            [JsonProperty("system_channel_id")]
            public string SystemChannelId { get; set; }
        }

        public class Channel
        {
            public int? position { get; set; }

            public string topic { get; set; }

            public int? bitrate { get; set; }

            public List<Overwrite> permission_overwrites { get; set; }

            public bool nsfw { get; set; }

            public string application_id { get; set; }
            
            [JsonProperty("rate_limit_per_user")]
            public int? RateLimitPerUser { get; set; }
        }

        public class Role
        {
            [JsonProperty("permissions")]
            public string Permissions { get; set; }
            
            [JsonProperty("color")]
            public int Color { get; set; }
            
            [JsonProperty("hoist")]
            public bool Hoist { get; set; }
            
            public bool mentionable { get; set; }

            public int? allow { get; set; }

            public int? deny { get; set; }
        }

        public class Invite
        {
            public string code { get; set; }

            public string channel_id { get; set; }

            public string inviter_id { get; set; }

            public int? max_uses { get; set; }

            public int? uses { get; set; }

            public int? max_age { get; set; }

            public bool temporary { get; set; }
        }

        public class User
        {
            public bool deaf { get; set; }

            public bool mute { get; set; }

            public string nick { get; set; }

            public string avatar_hash { get; set; }
        }

        public class Integration
        {
            [JsonProperty("enable_emoticons")]
            public bool EnableEmoticons { get; set; }
            
            [JsonProperty("expire_behavior")]
            public int ExpireBehavior { get; set; }

            [JsonProperty("expire_grace_period")]
            public int ExpireGracePeriod { get; set; }
        }
    }
}
