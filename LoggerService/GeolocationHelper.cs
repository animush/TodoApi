using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common
{
    public class GeolocationHelper
    {
        private readonly HttpClient _httpClient;
        public GeolocationHelper()
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };

        }
        private async Task<string> GetIPAddress()
        {

            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");
            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }
            return "";
        }
        public async Task<string> GetGeoInfo()
        {
            var ipAddress = await GetIPAddress();
            var response = await _httpClient.GetAsync($"http://api.ipstack.com/" + ipAddress + "?access_key=6a148115d6a9492019dd53d9c118f73a");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            return null;
        }
    }
}
