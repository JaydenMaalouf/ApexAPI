using Newtonsoft.Json;

namespace ApexLegendsAPI.Classes
{
    internal class ApexTempUserStats
    {
        [JsonProperty]
        public bool PlayerFound { get; internal set; }
        [JsonProperty]
        public int Level { get; internal set; }
        [JsonProperty]
        public int Kills { get; internal set; }
        [JsonProperty]
        public float SkillRatio { get; internal set; }
        [JsonProperty]
        public int Visits { get; internal set; }
        [JsonProperty]
        public int Headshots { get; internal set; }
        [JsonProperty]
        public int Matches { get; internal set; }
        [JsonProperty]
        public int GlobalRank { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int KillsBloodhound { get; internal set; }
        [JsonProperty("kills_Gibraltar")]
        public int KillsGibraltar { get; internal set; }
        [JsonProperty("kills_Lifeline")]
        public int KillsLifeline { get; internal set; }
        [JsonProperty("kills_Pathfinder")]
        public int KillsPathfinder { get; internal set; }
        [JsonProperty("kills_Wraith")]
        public int KillsWraith { get; internal set; }
        [JsonProperty("kills_Bangalore")]
        public int KillsBangalore { get; internal set; }
        [JsonProperty("kills_Caustic")]
        public int KillsCaustic { get; internal set; }
        [JsonProperty("kills_Mirage")]
        public int KillsMirage { get; internal set; }
        [JsonProperty("headshots_Bloodhound")]
        public int HeadshotsBloodhound { get; internal set; }
        [JsonProperty("headshots_Gibraltar")]
        public int HeadshotsGibraltar { get; internal set; }
        [JsonProperty("headshots_Lifeline")]
        public int HeadshotsLifeline { get; internal set; }
        [JsonProperty("headshots_Pathfinder")]
        public int HeadshotsPathfinder { get; internal set; }
        [JsonProperty("headshots_Wraith")]
        public int HeadshotsWraith { get; internal set; }
        [JsonProperty("headshots_Bangalore")]
        public int HeadshotsBangalore { get; internal set; }
        [JsonProperty("headshots_Caustic")]
        public int HeadshotsCaustic { get; internal set; }
        [JsonProperty("headshots_Mirage")]
        public int HeadshotsMirage { get; internal set; }
        [JsonProperty("matches__Bloodhound")]
        public int MatchesBloodhound { get; internal set; }
        [JsonProperty("matches_Gibraltar")]
        public int MatchesGibraltar { get; internal set; }
        [JsonProperty("matches_Lifeline")]
        public int MatchesLifeline { get; internal set; }
        [JsonProperty("matches_Pathfinder")]
        public int MatchesPathfinder { get; internal set; }
        [JsonProperty("matches_Wraith")]
        public int MatchesWraith { get; internal set; }
        [JsonProperty("matches_Bangalore")]
        public int MatchesBangalore { get; internal set; }
        [JsonProperty("matches_Caustic")]
        public int MatchesCaustic { get; internal set; }
        [JsonProperty("matches_Mirage")]
        public int MatchesMirage { get; internal set; }
    }
}
