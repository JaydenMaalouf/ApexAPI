namespace ApexLegendsAPI.Classes
{
    public class ApexUserLegendsStats
    {
        internal ApexUserLegendsStats(ApexTempUserStats data)
        {
            Bangalore = new ApexUserLegendStats(data.KillsBangalore, data.HeadshotsBangalore, data.MatchesBangalore);
            Bloodhound = new ApexUserLegendStats(data.KillsBloodhound, data.HeadshotsBloodhound, data.MatchesBloodhound);
            Caustic = new ApexUserLegendStats(data.KillsCaustic, data.HeadshotsCaustic, data.MatchesCaustic);
            Gibraltar = new ApexUserLegendStats(data.KillsGibraltar, data.HeadshotsGibraltar, data.MatchesGibraltar);
            Lifeline = new ApexUserLegendStats(data.KillsLifeline, data.HeadshotsLifeline, data.MatchesLifeline);
            Mirage = new ApexUserLegendStats(data.KillsMirage, data.HeadshotsMirage, data.MatchesMirage);
            Pathfinder = new ApexUserLegendStats(data.KillsPathfinder, data.HeadshotsPathfinder, data.MatchesPathfinder);
            Wraith = new ApexUserLegendStats(data.KillsWraith, data.HeadshotsWraith, data.MatchesWraith);
        }

        public ApexUserLegendStats Bangalore { get; internal set; }
        public ApexUserLegendStats Bloodhound { get; internal set; }
        public ApexUserLegendStats Caustic { get; internal set; }
        public ApexUserLegendStats Gibraltar { get; internal set; }
        public ApexUserLegendStats Lifeline { get; internal set; }
        public ApexUserLegendStats Mirage { get; internal set; }
        public ApexUserLegendStats Pathfinder { get; internal set; }
        public ApexUserLegendStats Wraith { get; internal set; }
    }
}
