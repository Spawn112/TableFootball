namespace TableFootball.Website.Models.Components.AllMatches
{
    using System;

    public class MatchEntry
    {
        public int Team1Score { get; set; }
        public string Team1Players { get; set; }
        public int Team2Score { get; set; }
        public string Team2Players { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}