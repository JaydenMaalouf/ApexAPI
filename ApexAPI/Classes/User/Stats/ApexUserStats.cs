namespace ApexLegendsAPI.Classes
{
    public class ApexUserStats
    {
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
            }
        }

        public int Level { get; internal set; }
        public int Kills { get; internal set; }
        public float SkillRatio { get; internal set; }
        public int Visits { get; internal set; }
        public int Headshots { get; internal set; }
        public int Matches { get; internal set; }
        public int GlobalRank { get; internal set; }
        public ApexUserLegendsStats Legends { get; internal set; }
    }
}
