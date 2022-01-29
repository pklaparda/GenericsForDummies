using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GenericsForDummies
{
    public class HttpCaller
    {
        public HttpCaller()
        {
            _httpClient = new HttpClient();
        }

        private HttpClient _httpClient;
        
        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(str);
                }
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error", ex);
                return default;
            }
        }
    }
}
