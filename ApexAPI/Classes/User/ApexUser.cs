using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;

using ApexLegendsAPI.Enums;
using ApexLegendsAPI.Interfaces;

namespace ApexLegendsAPI.Classes
{
    public class ApexUser : IApexUser
    {
        internal ApexUser() { }

        [JsonProperty("aid")]
        public Guid UserId { get; internal set; }

        [JsonProperty("name")]
        public string Username { get; internal set; }

        [JsonProperty]
        public ApexPlatformType Platform { get; internal set; }

        [JsonProperty("avatar")]
        public string AvatarURL { get; internal set; }

        [JsonProperty("legend")]
        public ApexLegendType CurrentLegend { get; internal set; }

        public async Task<ApexUserStats> GetStatsAsync()
        {
            if (UserId == Guid.Empty)
            {
                if (ApexAPI.ThrowExceptions) throw new Exception("UserId cannot be Null or Empty.");
                return null;
            }

            var content = await ApexAPI.SendRequest($"api/player.php", new KeyValuePair<string, string>("aid", $"{UserId.ToString("N").ToLower()}"));
            if (string.IsNullOrWhiteSpace(content))
            {
                if (ApexAPI.ThrowExceptions) throw new Exception("Server responded with null content.");
                return null;
            }

            var result = JsonConvert.DeserializeObject<ResultError>(content);
            if (result.IsError)
            {
                if (ApexAPI.ThrowExceptions) throw new Exception($"An error has occured: {result.ErrorMessage}");
                return null;
            }

            var userData = JsonConvert.DeserializeObject<ApexTempUserStats>(content);
            if (userData.PlayerFound == false)
            {
                if (ApexAPI.ThrowExceptions) throw new Exception("Unable to find specific users stats.");
                return null;
            }

            return new ApexUserStats(userData);
        }
    }
}