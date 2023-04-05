namespace TableFootball.Webstire.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using TableFootball.Website;
    using TableFootball.Website.Models.Components.Scoreboard;

    public class ScoreboardController : Controller
    {
        public ActionResult Index()
        {
            var model = new ScoreboardModel();
            var players = PresentationFactory.PlayerService.AllPlayers().OrderByDescending(p => p.Ranking);
            var i = 0;
            var previousPlayerRanking = 0;
            foreach (var player in players)
            {
                var entry = new ScoreboardEntry() { PlayerName = player.Name, Score = player.Ranking };
                entry.Winrate = CalculateWinrate(player);
                if (previousPlayerRanking != player.Ranking)
                {
                    i++;
                    entry.Position = i;
                }
                model.Entries.Add(entry);
                previousPlayerRanking = player.Ranking;
            }
            return PartialView("/Views/Components/Scoreboard/Scoreboard.cshtml", model);
        }

        private static int CalculateWinrate(Datatypes.Entities.Player player)
        {
            var numberOfGamesPlayed = player.NumberOfWins + player.NumberOfLosses;
            return numberOfGamesPlayed == 0 ? numberOfGamesPlayed : (int)((double)(player.NumberOfWins / (double)numberOfGamesPlayed) * 100);
        }
    }
}