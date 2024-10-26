﻿using Newtonsoft.Json;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    internal class RateLimitContent : BasePoolable
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        
        [JsonProperty("code")]
        public int? Code { get; set; }

        protected override void EnterPool()
        {
            Message = null;
            Code = null;
        }
    }
}