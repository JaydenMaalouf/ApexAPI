using System;
using System.Linq;
using System.Collections.Generic;

using ApexLegendsAPI.Enums;

namespace ApexLegendsAPI.Classes
{
    public class ApexUserStats
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public int Level { get; internal set; }
        public int Kills { get; internal set; }
        public float SkillRatio { get; internal set; }
        public int Visits { get; internal set; }
        public int Headshots { get; internal set; }
        public int Matches { get; internal set; }
        public int GlobalRank { get; internal set; }
        public ApexUserLegendsStats Legends { get; internal set; }
        public IReadOnlyDictionary<DateTime, ApexDailyStats> DailyStats { get; internal set; }

        private ApexLegendType CurrentLegend { get; set; }

        internal ApexUserStats(ApexTempUserStats stats)
        {
            if (stats.PlayerFound)
            {
                Level = stats.Level;
                Kills = stats.Kills;
                SkillRatio = stats.SkillRatio;
                Visits = stats.Visits;
                Headshots = stats.Headshots;
                Matches = stats.Matches;
                GlobalRank = stats.GlobalRank;
                Legends = new ApexUserLegendsStats(stats);
                CurrentLegend = stats.CurrentLegend;

                if (stats.DailyStats != null)
                {
                    DailyStats = stats.DailyStats.ToDictionary(k => epoch.AddSeconds(k.Key), k => k.Value);
                }
            }
        }

        public ApexDailyStats GetStatsToday()
        {
            var todaysStats = GetStatsFrom(DateTime.UtcNow.Date);
            if (todaysStats != null)
            {
                return todaysStats;
            }

            if (ApexAPI.ThrowExceptions) throw new Exception("Todays stats don't exist.");
            return null;
        }

        public ApexDailyStats GetStatsFrom(DateTime UtcDate)
        {
            if (DailyStats == null)
            {
                if (ApexAPI.ThrowExceptions) throw new Exception("Daily stats doesn't exist.");
                return null;
            }

            if (DailyStats.TryGetValue(UtcDate, out var dailyStats))
            {
                return dailyStats;
            }

            if (ApexAPI.ThrowExceptions) throw new Exception("Cannot retrieve dates stats.");
            return null;
        }

        public ApexUserLegendStats GetCurrentLegendStats()
        {
            if (CurrentLegend == ApexLegendType.Unknown)
            {
                if (ApexAPI.ThrowExceptions) throw new Exception("Cannot retrieve Legend's stats.");
                return null;
            }

            return GetLegendStats(CurrentLegend);
        }
        
        public ApexUserLegendStats GetLegendStats(ApexLegendType LegendType)
        {
            switch (LegendType)
            {
                case ApexLegendType.Bangalore: return Legends.Bangalore;
                case ApexLegendType.Bloodhound: return Legends.Bloodhound;
                case ApexLegendType.Caustic: return Legends.Caustic;
                case ApexLegendType.Gibraltar: return Legends.Gibraltar;
                case ApexLegendType.Lifeline: return Legends.Lifeline;
                case ApexLegendType.Mirage: return Legends.Mirage;
                case ApexLegendType.Pathfinder: return Legends.Pathfinder;
                case ApexLegendType.Wraith: return Legends.Wraith;
            }

            if (ApexAPI.ThrowExceptions) throw new Exception("Cannot retrieve Legend's stats.");
            return null;
        }
    }
}
