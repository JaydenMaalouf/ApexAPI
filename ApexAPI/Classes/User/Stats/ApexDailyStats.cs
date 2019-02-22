using Newtonsoft.Json;

namespace ApexLegendsAPI.Classes
{
    public class ApexDailyStats
    {
        [JsonProperty]
        public int Kills { get; internal set; }

        [JsonProperty]
        public int Headshots { get; internal set; }

        [JsonProperty]
        public int Matches { get; internal set; }

        [JsonProperty]
        public int Damage { get; internal set; }
    }
}
