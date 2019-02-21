using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApexLegendsAPI
{
    public class ApexAPI
    {
        private static string RequestURL = "https://apextab.com/api/";
        private static HttpClient HttpClient = new HttpClient();

        public ApexAPI() { }
        public ApexAPI(string NewURL)
        {
            RequestURL = NewURL;
        }

        public async Task<IEnumerable<ApexUser>> GetUsers(string PlayerName, ApexPlatform Platform = ApexPlatform.PC)
        {
            var content = await SendRequest($"search.php?search={PlayerName}&platform={Platform.ToString().ToLower()}");
            if (!string.IsNullOrWhiteSpace(content))
            {
                var searchResults = JsonConvert.DeserializeObject<SearchResult>(content);
                if (searchResults != null)
                {
                    return searchResults.Users;
                }
            }
            return null;
        }

        public async Task<ApexUser> GetUser(string PlayerName, ApexPlatform Platform = ApexPlatform.PC)
        {
            var searchResults = await GetUsers(PlayerName, Platform);
            if (searchResults.Count() > 0)
            {
                return searchResults.ElementAt(0);
            }
            return null;
        }

        public static async Task<string> SendRequest(string URL)
        {
            var response = await HttpClient.GetAsync($"{RequestURL}{URL}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }

}
