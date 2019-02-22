using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using ApexLegendsAPI.Enums;
using ApexLegendsAPI.Classes;
using System.Web;

namespace ApexLegendsAPI
{
    public class ApexAPI
    {
        private static HttpClient HttpClient = new HttpClient();
        
        public ApexAPI(string RequestURL = "http://apextab.com/")
        {
            HttpClient.BaseAddress = new Uri(RequestURL);
        }

        public async Task<IEnumerable<ApexUser>> GetUsersAsync(string PlayerName, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            if (string.IsNullOrWhiteSpace(PlayerName))
            {
                return null;
            }

            var content = await SendRequest($"api/search.php", new KeyValuePair<string, string>("search", PlayerName), new KeyValuePair<string, string>("platform", Platform.ToString().ToLower()));
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
            if (string.IsNullOrWhiteSpace(PlayerName))
            {
                return null;
            }

            var searchResults = await GetUsersAsync(PlayerName, Platform);
            if (searchResults != null && searchResults.Count() > 0)
            {
                return searchResults.ElementAt(0);
            }
            return null;
        }

        public async Task<ApexUser> GetUserAsync(Guid UserId, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            if (UserId == Guid.Empty)
            {
                return null;
            }

            var content = await SendRequest($"api/player.php", new KeyValuePair<string, string>("aid", $"{UserId.ToString("N").ToLower()}"));
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

        internal static async Task<string> SendRequest(string path, params KeyValuePair<string, string> [] UrlParameters)
        {
            var urlParametersString = string.Join("&", UrlParameters.Select(x => x.Key + "=" + x.Value).ToArray());
            var queryUrl = (string.IsNullOrWhiteSpace(urlParametersString) ? path : $"{path}?{urlParametersString}");
            var response = await HttpClient.GetAsync(queryUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }
    }

}
