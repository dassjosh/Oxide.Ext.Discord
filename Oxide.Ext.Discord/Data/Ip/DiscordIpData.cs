using System.Collections.Generic;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Services.IpApi;
using ProtoBuf;

namespace Oxide.Ext.Discord.Data.Ip
{
    [ProtoContract]
    internal sealed class DiscordIpData : BaseDataFile<DiscordIpData>
    {
        [ProtoMember(1)] 
        private readonly Dictionary<string, IpData> _ips = new();

        public bool HasData(string ip) => _ips.ContainsKey(ip);
        
        public void AddData(string ip, IpResult result)
        {
            _ips[ip] = new IpData(result);
            OnDataChanged();
        }

        public string GetCountryName(string ip) => _ips.TryGetValue(ip, out IpData data) ? data.CountryName : "Unknown";
        public string GetCountryCode(string ip) => _ips.TryGetValue(ip, out IpData data) ? data.CountryCode : string.Empty;
        
        internal override void OnDataLoaded(DataFileInfo info)
        {
            base.OnDataLoaded(info);
            int count = _ips.Count;
            _ips.RemoveAll(ip => ip.IsExpired);
            if (count != _ips.Count)
            {
                OnDataChanged();
            }
        }
    }
}