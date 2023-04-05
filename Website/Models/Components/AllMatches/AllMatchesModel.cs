namespace TableFootball.Website.Models.Components.AllMatches
{
    using System.Collections.Generic;

    public class AllMatchesModel
    {
        public string Title { get; set; } = "Game History";
        public string Team1Score { get; set; } = " TEAM 1 SCORE";
        public string Team1Players { get; set; } = " TEAM 1 PLAYERS";
        public string Team2Score { get; set; } = " TEAM 2 SCORE";
        public string Team2Players { get; set; } = " TEAM 2 PLAYERS";
        public string PlayedAtLabel { get; set; } = "PLAYED AT";
        public int NumberOfResults { get; set; }
        public int TotalNumberOfMatches { get; set; }
        public List<MatchEntry> Entries { get; set; } = new List<MatchEntry>();
    }
}