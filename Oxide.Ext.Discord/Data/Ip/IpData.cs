using System;
using Oxide.Ext.Discord.Configuration;
using Oxide.Ext.Discord.Services.IpApi;
using ProtoBuf;

namespace Oxide.Ext.Discord.Data.Ip
{
    [ProtoContract]
    internal class IpData
    {
        [ProtoMember(1)]
        public string CountryCode { get; set; }
        
        [ProtoMember(2)]
        public string CountryName { get; set; }
        
        [ProtoMember(3)]
        public DateTime CreatedDate { get; set; }

        public bool IsExpired
        {
            get
            {
                DiscordIpConfig config = DiscordConfig.Instance.Ip;
                if (!config.Enabled)
                {
                    return true;
                }
                
                float duration = config.StoreIpDuration;
                if (duration < 0)
                {
                    return false;
                }
                return DateTime.UtcNow > CreatedDate + TimeSpan.FromDays(duration);
            }
        }

        public IpData() { }

        public IpData(IpResult result)
        {
            CountryName = result.Country;
            CountryCode = result.CountryCode.ToLower();
            CreatedDate = DateTime.UtcNow;
        }
    }
}