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
        public static bool ThrowExceptions = false;
        private static HttpClient HttpClient = new HttpClient();
        
        public ApexAPI(string RequestURL = "http://apextab.com/", bool throwExceptions = false)
        {
            HttpClient.BaseAddress = new Uri(RequestURL);
            ThrowExceptions = throwExceptions;
        }

        public async Task<IEnumerable<ApexUser>> GetUsersAsync(string Username, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                if (ThrowExceptions) throw new Exception("Username cannot be Null, Empty or Whitespace.");
                return null;
            }

            var content = await SendRequest($"api/search.php", new KeyValuePair<string, string>("search", Username), new KeyValuePair<string, string>("platform", Platform.ToString().ToLower()));
            if (string.IsNullOrWhiteSpace(content))
            {
                if (ThrowExceptions) throw new Exception("Server responded with null content.");
                return null;
            }

            var result = JsonConvert.DeserializeObject<ResultError>(content);
            if (result.IsError)
            {
                if (ThrowExceptions) throw new Exception($"An error has occured: {result.ErrorMessage}");
                return null;
            }

            var searchResults = JsonConvert.DeserializeObject<SearchResult>(content);
            if (searchResults == null || searchResults.Users == null)
            {
                if (ThrowExceptions) throw new Exception("Unable to deserialize the response properly.");
                return null;
            }
            return searchResults.Users;
        }

        public async Task<ApexUser> GetUserAsync(string Username, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                if (ThrowExceptions) throw new Exception("Username cannot be Null, Empty or Whitespace.");
                return null;
            }

            var searchResults = await GetUsersAsync(Username, Platform);
            if (searchResults == null || searchResults.Count() == 0)
            {
                if (ThrowExceptions) throw new Exception("Unable to find specific user.");
                return null;
            }
            return searchResults.ElementAt(0);
        }

        public async Task<ApexUser> GetUserAsync(Guid UserId, ApexPlatformType Platform = ApexPlatformType.PC)
        {
            if (UserId == Guid.Empty)
            {
                if (ThrowExceptions) throw new Exception("UserId cannot be Null or Empty.");
                return null;
            }

            var content = await SendRequest($"api/player.php", new KeyValuePair<string, string>("aid", $"{UserId.ToString("N").ToLower()}"));
            if (string.IsNullOrWhiteSpace(content))
            {
                if (ThrowExceptions) throw new Exception("Server responded with null content.");
                return null;
            }

            var result = JsonConvert.DeserializeObject<ResultError>(content);
            if (result.IsError)
            {
                if (ThrowExceptions) throw new Exception($"An error has occured: {result.ErrorMessage}");
                return null;
            }

            return JsonConvert.DeserializeObject<ApexUser>(content);
        }

        internal static async Task<string> SendRequest(string path, params KeyValuePair<string, string> [] UrlParameters)
        {
            var urlParametersString = string.Join("&", UrlParameters.Select(x => x.Key + "=" + x.Value).ToArray());
            var queryUrl = (string.IsNullOrWhiteSpace(urlParametersString) ? path : $"{path}?{urlParametersString}");

            var response = await HttpClient.GetAsync(queryUrl);
            if (!response.IsSuccessStatusCode)
            {
                if (ThrowExceptions) throw new Exception("An error occured when sending GET Request to server.");
                return null;
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
