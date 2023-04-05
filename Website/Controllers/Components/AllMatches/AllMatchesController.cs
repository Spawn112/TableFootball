namespace TableFootball.Website.Controllers.Components.AllMatches
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using TableFootball.Website.Models.Components.AllMatches;

    public class AllMatchesController : Controller
    {
        public ActionResult Index(int numberOfResultsToDisplay = 0, int page = 0)
        {
            var model = new AllMatchesModel();
            var allPlayers = PresentationFactory.PlayerService.AllPlayers().ToDictionary(key => key.ID, value => value);
            var allMatches = PresentationFactory.MatchService.AllMatches().OrderByDescending(m => m.PlayedAt).AsEnumerable();
            model.TotalNumberOfMatches = allMatches.Count();
            if (numberOfResultsToDisplay > 0)
            {
                allMatches = allMatches.Skip((page > 0 ? page - 1 : page) * numberOfResultsToDisplay).Take(numberOfResultsToDisplay);
                model.NumberOfResults = numberOfResultsToDisplay;
            }
            foreach (var match in allMatches)
            {
                var entry = new MatchEntry()
                {
                    Team1Score = match.Team1Score,
                    Team2Score = match.Team2Score,
                    PlayedAt = match.PlayedAt
                };
                if (match.Team1Player1 == Guid.Empty || match.Team1Player2 == Guid.Empty)
                {
                    entry.Team1Players = match.Team1Player1 == Guid.Empty ? allPlayers[match.Team1Player2].Name : allPlayers[match.Team1Player1].Name;
                }
                else
                {
                    entry.Team1Players = allPlayers[match.Team1Player1].Name + " + " + allPlayers[match.Team1Player2].Name;
                }
                if (match.Team2Player1 == Guid.Empty || match.Team2Player2 == Guid.Empty)
                {
                    entry.Team2Players = match.Team2Player1 == Guid.Empty ? allPlayers[match.Team2Player2].Name : allPlayers[match.Team2Player1].Name;
                }
                else
                {
                    entry.Team2Players = allPlayers[match.Team2Player1].Name + " + " + allPlayers[match.Team2Player2].Name;
                }

                model.Entries.Add(entry);
            }
            return PartialView("/Views/Components/AllMatches/AllMatches.cshtml", model);
        }
    }
}