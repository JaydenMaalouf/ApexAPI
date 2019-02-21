using ApexLegendsAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApexLegendsAPI.Classes
{
    internal class ApexTempUserData
    {
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
        public int kills_Bloodhound { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Gibraltar { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Lifeline { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Pathfinder { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Wraith { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Bangalore { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Caustic { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int kills_Mirage { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Bloodhound { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Gibraltar { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Lifeline { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Pathfinder { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Wraith { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Bangalore { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Caustic { get; internal set; }
        [JsonProperty("kills_Bloodhound")]
        public int headshots_Mirage { get; internal set; }
        [JsonProperty]
        public int matches_Bloodhound { get; internal set; }
        [JsonProperty]
        public int matches_Gibraltar { get; internal set; }
        [JsonProperty]
        public int matches_Lifeline { get; internal set; }
        [JsonProperty]
        public int matches_Pathfinder { get; internal set; }
        [JsonProperty]
        public int matches_Wraith { get; internal set; }
        [JsonProperty]
        public int matches_Bangalore { get; internal set; }
        [JsonProperty]
        public int matches_Caustic { get; internal set; }
        [JsonProperty]
        public int matches_Mirage { get; internal set; }
    }

    public class ApexUserData
    {
        internal ApexUserData(ApexTempUserData data)
        {
            Level = data.Level;
            Kills = data.Kills;
            SkillRatio = data.SkillRatio;
            Visits = data.Visits;
            Headshots = data.Headshots;
            Matches = data.Matches;
            GlobalRank = data.GlobalRank;
            Legends = new ApexUserLegends(data);
        }

        public int Level { get; internal set; }
        public int Kills { get; internal set; }
        public float SkillRatio { get; internal set; }
        public int Visits { get; internal set; }
        public int Headshots { get; internal set; }
        public int Matches { get; internal set; }
        public int GlobalRank { get; internal set; }
        public ApexUserLegends Legends { get; internal set; }
    }

    public class ApexUserLegends
    {
        internal ApexUserLegends(ApexTempUserData data)
        {
            Bangalore = new ApexUserLegendData(data.kills_Bangalore, data.headshots_Bangalore, data.matches_Bangalore);
            Bloodhound = new ApexUserLegendData(data.kills_Bloodhound, data.headshots_Bloodhound, data.matches_Bloodhound);
            Caustic = new ApexUserLegendData(data.kills_Caustic, data.headshots_Caustic, data.matches_Caustic);
            Gibraltar = new ApexUserLegendData(data.kills_Gibraltar, data.headshots_Gibraltar, data.matches_Gibraltar);
            Lifeline = new ApexUserLegendData(data.kills_Lifeline, data.headshots_Lifeline, data.matches_Lifeline);
            Mirage = new ApexUserLegendData(data.kills_Mirage, data.headshots_Mirage, data.matches_Mirage);
            Pathfinder = new ApexUserLegendData(data.kills_Pathfinder, data.headshots_Pathfinder, data.matches_Pathfinder);
            Wraith = new ApexUserLegendData(data.kills_Wraith, data.headshots_Wraith, data.matches_Wraith);
        }

        public ApexUserLegendData Bangalore { get; internal set; }
        public ApexUserLegendData Bloodhound { get; internal set; }
        public ApexUserLegendData Caustic { get; internal set; }
        public ApexUserLegendData Gibraltar { get; internal set; }
        public ApexUserLegendData Lifeline { get; internal set; }
        public ApexUserLegendData Mirage { get; internal set; }
        public ApexUserLegendData Pathfinder { get; internal set; }
        public ApexUserLegendData Wraith { get; internal set; }
    }

    public class ApexUserLegendData
    {
        internal ApexUserLegendData(int kills, int headshots, int matches)
        {
            Kills = kills;
            Headshots = headshots;
            Matches = matches;
        }
        public int Kills { get; internal set; }
        public int Headshots { get; internal set; }
        public int Matches { get; internal set; }
    }

}
