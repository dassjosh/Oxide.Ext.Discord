using System.Threading.Tasks;
using Oxide.Ext.Discord.Data.Ip;
using Oxide.Ext.Discord.Libraries;
using Oxide.Ext.Discord.Services.IpApi;

namespace Oxide.Ext.Discord.Callbacks.Data
{
    internal class GetIpDataCallback : BaseAsyncCallback
    {
        private string _ip;

        public static void Start(string ip)
        {
            GetIpDataCallback callback = DiscordPool.Internal.Get<GetIpDataCallback>();
            callback.Init(ip);
            callback.Run();
        }

        private void Init(string ip)
        {
            _ip = ip;
        }
        
        protected override async ValueTask HandleCallback()
        {
            IpResult result = await IpApiService.Instance.GetCountryCode(_ip).ConfigureAwait(false);
            if (result != null)
            {
                DiscordIpData.Instance.AddData(_ip, result);
            }
        }

        protected override string GetExceptionMessage()
        {
            return $"IP: {_ip}";
        }
    }
}