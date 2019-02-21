namespace ApexLegendsAPI.Classes
{
    public class ApexUserLegendStats
    {
        internal ApexUserLegendStats(int kills, int headshots, int matches)
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
