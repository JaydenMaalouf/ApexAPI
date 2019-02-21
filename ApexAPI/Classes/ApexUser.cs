using ApexLegendsAPI.Classes;
using ApexLegendsAPI.Interfaces;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ApexLegendsAPI
{
    public class ApexUser : IApexUser
    {
        internal ApexUser() { }

        [JsonProperty("aid")]
        public string UserId { get; internal set; }

        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        public ApexPlatform Platform { get; internal set; }

        [JsonProperty("avatar")]
        public string AvatarURL { get; internal set; }

        [JsonProperty("legend")]
        public ApexLegendTypes CurrentLegend { get; internal set; }

        [JsonProperty]
        public int Level { get; internal set; }

        [JsonProperty]
        public int Kills { get; internal set; }

        public async Task<ApexUserData> GetStatsAsync()
        {
            var content = await ApexAPI.SendRequest($"player.php?aid={UserId}");
            if (!string.IsNullOrWhiteSpace(content))
            {
                var userData = JsonConvert.DeserializeObject<ApexTempUserData>(content);
                if (userData != null)
                {
                    return new ApexUserData(userData);
                }
            }
            return null;
        }
    }
}