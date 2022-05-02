using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Text;

namespace Algorand.V2
{
    public class HttpClientConfigurator
    {
        public static HttpClient ConfigureHttpClient(string host, string token, string tokenHeader = "", int timeout = -1)
        {
            HttpClient _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri(host);
            if (!_httpClient.BaseAddress.IsAbsoluteUri)
            {
                throw new ArgumentException("Host must be an absolute path.");
            }
            else
            {
                if (!_httpClient.BaseAddress.AbsolutePath.EndsWith("/"))
                {
                    UriBuilder uriBuilder = new UriBuilder(_httpClient.BaseAddress);
                    uriBuilder.Path = _httpClient.BaseAddress.AbsolutePath + "/";
                    _httpClient.BaseAddress = uriBuilder.Uri;
                }
            }
            

            if (string.IsNullOrEmpty(tokenHeader))
            {
                if (host.Contains("algorand.api.purestake.io") || host.Contains("bsngate.com/api"))
                {
                    tokenHeader = "X-API-Key";
                }
                else
                {
                    tokenHeader = "X-Algo-API-Token";
                }
            }

            if (tokenHeader != null && tokenHeader.Length > 0)
                _httpClient.DefaultRequestHeaders.Add(tokenHeader, token);

            _httpClient.Timeout = timeout > 0 ? (TimeSpan.FromMilliseconds((double)timeout)) : Timeout.InfiniteTimeSpan;

            return _httpClient;
        }
    }
}
