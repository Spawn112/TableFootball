namespace TableFootball.Website.Models.Components.Scoreboard
{
    using System.Collections.Generic;

    public class ScoreboardModel
    {
        public string Title { get; set; } = "Mercell Champions League Table Football";
        public string Header { get; set; } = "Leaderboard";
        public string HeaderPosition { get; set; } = "POSITION";
        public string HeaderName { get; set; } = "NAME";
        public string HeaderWinrate { get; set; } = "WINRATE";
        public string HeaderScore { get; set; } = "SCORE";
        public List<ScoreboardEntry> Entries { get; set; } = new List<ScoreboardEntry>();
    }
}