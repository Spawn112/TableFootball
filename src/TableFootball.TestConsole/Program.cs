#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace TableFootball.TestConsole
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    using System;
    using System.Linq;
    using TableFootball.Data.Enums;
    using TableFootball.Website;

    public class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        public static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            var allMatches = PresentationFactory.MatchService.AllMatches().OrderBy(m => m.PlayedAt);
            var allPlayers = PresentationFactory.PlayerService.AllPlayers();
            foreach (var player in allPlayers)
            {
                player.Ranking = 1500;
            }
            foreach (var match in allMatches.Where(m => m.Team1Player1 != Guid.Empty && m.Team1Player2 != Guid.Empty && m.Team2Player1 != Guid.Empty && m.Team2Player2 != Guid.Empty))
            {
                var team1 = allPlayers.Where(p => p.ID == match.Team1Player1 || p.ID == match.Team1Player2);
                var team1Player1Rank = team1.First().Ranking;
                var team1Player2Rank = team1.Last().Ranking;
                var team2 = allPlayers.Where(p => p.ID == match.Team2Player1 || p.ID == match.Team2Player2);
                var team2Player1Rank = team2.First().Ranking;
                var team2Player2Rank = team2.Last().Ranking;
                PresentationFactory.CalculateRankService.UpdateRankings(team1, team2, match.Team1Score > match.Team2Score ? GameOutcome.Team1Win : GameOutcome.Team2Win, match);
                var i = 1;
                foreach (var player in team1)
                {
                    Console.Write(player.Name + " ");
                    i++;
                }
                Console.Write("vs ");
                i = 1;
                foreach (var player in team2)
                {
                    Console.Write(player.Name + " ");
                    i++;
                }
                Console.Write(Environment.NewLine);
                Console.WriteLine(team1.First().Name + "(" + team1Player1Rank + ")" + ": " + (team1.First().Ranking - team1Player1Rank));
                Console.WriteLine(team1.Last().Name + "(" + team1Player2Rank + ")" + ": " + (team1.Last().Ranking - team1Player2Rank));
                Console.WriteLine(team2.First().Name + "(" + team2Player1Rank + ")" + ": " + (team2.First().Ranking - team2Player1Rank));
                Console.WriteLine(team2.Last().Name + "(" + team2Player2Rank + ")" + ": " + (team2.Last().Ranking - team2Player2Rank));
                Console.Write(Environment.NewLine);
            }
            foreach (var player in allPlayers.OrderByDescending(p => p.Ranking))
            {
                Console.WriteLine(player.Name + "(W:" + player.NumberOfWins + " L:" + player.NumberOfLosses + "): " + player.Ranking);
            }
        }
    }
}