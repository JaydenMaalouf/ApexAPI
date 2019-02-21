using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using ApexLegendsAPI.Classes;
using ApexLegendsAPI.Interfaces;

namespace ApexLegendsAPI
{
    public class ApexUser : IApexUser
    {
        internal ApexUser() { }

        [JsonProperty("aid")]
        public Guid UserId { get; internal set; }

        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        public ApexPlatform Platform { get; internal set; }

        [JsonProperty("avatar")]
        public string AvatarURL { get; internal set; }

        [JsonProperty("legend")]
        public ApexLegendTypes CurrentLegend { get; internal set; }

        public async Task<ApexUserStats> GetStatsAsync()
        {
            var content = await ApexAPI.SendRequest($"player.php?aid={UserId.ToString("N").ToLower()}");
            if (!string.IsNullOrWhiteSpace(content))
            {
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