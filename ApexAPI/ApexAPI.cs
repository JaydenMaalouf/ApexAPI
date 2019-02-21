using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using ApexLegendsAPI.Enums;
using ApexLegendsAPI.Classes;

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

        public async Task<IEnumerable<ApexUser>> GetUsersAsync(string PlayerName, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            var content = await SendRequest($"search.php?search={PlayerName}&platform={Platform.ToString().ToLower()}");
            if (!string.IsNullOrWhiteSpace(content))
            {
                var result = JsonConvert.DeserializeObject<ResultError>(content);
                if (result.IsError)
                {
                    return null;
                }

                var searchResults = JsonConvert.DeserializeObject<SearchResult>(content);
                if (searchResults != null && searchResults.Users != null)
                {
                    return searchResults.Users;
                }
            }
            return null;
        }

        public async Task<ApexUser> GetUserAsync(string PlayerName, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            var searchResults = await GetUsersAsync(PlayerName, Platform);
            if (searchResults != null && searchResults.Count() > 0)
            {
                return searchResults.ElementAt(0);
            }
            return null;
        }

        public async Task<ApexUser> GetUserAsync(Guid PlayerId, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            var content = await SendRequest($"player.php?aid={PlayerId.ToString("N").ToLower()}");
            if (!string.IsNullOrWhiteSpace(content))
            {
                var result = JsonConvert.DeserializeObject<ResultError>(content);
                if (result.IsError)
                {
                    return null;
                }

                var user = JsonConvert.DeserializeObject<ApexUser>(content);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        internal static async Task<string> SendRequest(string URL)
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
