using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Oxide.Ext.Discord.Extensions;
using Oxide.Ext.Discord.Interfaces;
using Oxide.Ext.Discord.Logging;
using Oxide.Ext.Discord.Types;

namespace Oxide.Ext.Discord.Services.IpApi
{
    internal sealed class IpApiService : Singleton<IpApiService>
    {
        private readonly HttpClient _client;
        private readonly ILogger _logger = DiscordExtension.GlobalLogger;
        private readonly SemaphoreSlim _semaphore = new(5, 5);
        
        private int _remainingRequests = 45;
        private DateTimeOffset _limitReset = DateTimeOffset.MinValue;
        
        private const string RemainingRequestsHeader = "X-Rl";
        private const string RemainingSecondsHeader = "X-Ttl";
        private const int MaxRetries = 3;
        
        private IpApiService()
        {
            HttpClientHandler handler = new()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false
            };
            _client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromSeconds(15),
                BaseAddress = new Uri("http://ip-api.com/json/")
            };
            _client.DefaultRequestHeaders.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add( StringWithQualityHeaderValue.Parse("gzip"));
            _client.DefaultRequestHeaders.AcceptEncoding.Add(StringWithQualityHeaderValue.Parse("deflate"));
        }

        public ValueTask<IpResult> GetCountryCode(string ip)
        {
            _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCode)} Getting IP data for {{0}}", ip);
            string url = $"{ip}?fields=49155";
            return GetCountryCodeInternal(url, 0);
        }

        private async ValueTask<IpResult> GetCountryCodeInternal(string url, int retries)
        {
            if (retries++ >= MaxRetries)
            {
                _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} Failed to get IP data after {{0}} retries", retries);
                return null;
            }
            
            if (_remainingRequests <= 0 && _limitReset > DateTimeOffset.UtcNow)
            {
                _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} Rate Limit reached. Waiting for {{0}}", DateTimeOffset.UtcNow - _limitReset);
                await _limitReset.DelayUntil().ConfigureAwait(false);
            }
            
            HttpResponseMessage result = null;
            try
            {
                await _semaphore.WaitAsync().ConfigureAwait(false);
                _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} Start Request {{0}}", url);
                result = await _client.GetAsync(url).ConfigureAwait(false);
                if (result.IsSuccessStatusCode)
                {
                    string json = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                    IpResult ipResult = JsonConvert.DeserializeObject<IpResult>(json);
                    _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} Request Success for IP: {{0}}. IP Success: {{1}} Message: {{2}} Body:\n{{3}} ", url, ipResult?.IsSuccess ?? false, ipResult?.Message, json);
                    return ipResult?.IsSuccess ?? false ? ipResult : null;
                }

                if (retries >= MaxRetries)
                {
                    _logger.Error($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} An error occured during request. Code: {{0}} Message: {{1}}", result.StatusCode, await result.Content.ReadAsStringAsync().ConfigureAwait(false));
                }
                
                switch (result.StatusCode)
                {
                    case HttpStatusCode.ServiceUnavailable:
                    case HttpStatusCode.InternalServerError:
                        await (DateTimeOffset.UtcNow + TimeSpan.FromSeconds(1)).DelayUntil().ConfigureAwait(false);
                        return await GetCountryCodeInternal(url, retries).ConfigureAwait(false);
                }

                return null;
            }
            catch (JsonSerializationException ex)
            { 
                _logger.Exception($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} An error occured during JSON serialization.", ex);
                return null;
            }
            catch (Exception ex)
            {
                if (retries >= MaxRetries)
                {
                    _logger.Exception($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} An error occured during IP lookup.", ex);
                }
           
                await (DateTimeOffset.UtcNow + TimeSpan.FromSeconds(1)).DelayUntil().ConfigureAwait(false);
                return await GetCountryCodeInternal(url, retries).ConfigureAwait(false);
            }
            finally
            {
                _semaphore.Release();
                if (result?.Headers != null)
                {
                    ParseHeaders(result.Headers);
                }
            }
        }

        private void ParseHeaders(HttpResponseHeaders headers)
        {
            if (headers.TryGetInt(RemainingRequestsHeader, out int remaining) && remaining < _remainingRequests)
            {
                _remainingRequests = remaining;
            }

            if (headers.TryGetInt(RemainingSecondsHeader, out int seconds))
            {
                DateTimeOffset reset = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(seconds) + TimeSpan.FromMilliseconds(25);
                if (reset > _limitReset)
                {
                    _remainingRequests = remaining;
                    _limitReset = reset;
                }
            }
            
            _logger.Verbose($"{nameof(IpApiService)}.{nameof(GetCountryCodeInternal)} Parsed Headers. Remaining: {{0}} Limit Reset At: {{1}}", _remainingRequests, _limitReset);
        }
    }
}