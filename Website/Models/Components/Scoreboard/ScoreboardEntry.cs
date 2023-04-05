namespace TableFootball.Website.Models.Components.Scoreboard
{
    public class ScoreboardEntry
    {
        public int? Position { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Winrate { get; set; }
    }
}