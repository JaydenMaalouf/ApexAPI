using System;
using System.Threading.Tasks;

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

        [JsonProperty]
        public string Username { get; internal set; }

        [JsonProperty]
        public ApexPlatformTypes Platform { get; internal set; }

        [JsonProperty("avatar")]
        public string AvatarURL { get; internal set; }

        [JsonProperty("legend")]
        public ApexLegendTypes CurrentLegend { get; internal set; }

        public async Task<ApexUserStats> GetStatsAsync()
        {
            var content = await ApexAPI.SendRequest($"player.php?aid={UserId.ToString("N").ToLower()}");
            if (!string.IsNullOrWhiteSpace(content))
            {
                var result = JsonConvert.DeserializeObject<ResultError>(content);
                if (result.IsError)
                {
                    return null;
                }

                var userData = JsonConvert.DeserializeObject<ApexTempUserStats>(content);
                if (userData != null)
                {
                    return new ApexUserStats(userData);
                }
            }
            return null;
        }
    }
}