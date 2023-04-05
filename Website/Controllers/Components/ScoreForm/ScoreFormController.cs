namespace TableFootball.Website.Controllers.Components.ScoreForm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Website.Models.Components.ScoreForm;

    public class ScoreFormController : Controller
    {
        public ActionResult Index(ScoreFormModel model = null)
        {
            if (model == null)
            {
                model = new ScoreFormModel();
            }
            model.Players.AddRange(PresentationFactory.PlayerService.AllPlayers().OrderBy(p => p.Name));
            return PartialView("/Views/Components/ScoreForm/ScoreForm.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterScore(ScoreFormModel model)
        {
            if (model.Team1Score >= 10 || model.Team2Score >= 10)
            {
                if (model.Team1Player1 == Guid.Empty && model.Team1Player2 == Guid.Empty)
                {
                    AddErrorToModel(model, "Team 1 needs at least 1 member!");
                }
                else if (model.Team2Player1 == Guid.Empty && model.Team2Player2 == Guid.Empty)
                {
                    AddErrorToModel(model, "Team 2 needs at least 1 member!");
                }
                else if (string.IsNullOrEmpty(model.WarningMsg) && LatestMatchIsIdentical(model))
                {
                    AddWarningToModel(model, "You have already registered a match with this outcome, are you sure you want to register a match identical to the last registered match?");
                }
                else
                {
                    var match = new Match()
                    {
                        ID = Guid.NewGuid(),
                        PlayedAt = DateTime.Now,
                        Team1Player1 = model.Team1Player1,
                        Team1Player2 = model.Team1Player2,
                        Team2Player1 = model.Team2Player1,
                        Team2Player2 = model.Team2Player2,
                        Team1Score = model.Team1Score,
                        Team2Score = model.Team2Score
                    };
                    PresentationFactory.MatchService.SubmitMatch(match);
                    return RedirectToAction("index", "Home");
                }
            }
            else
            {
                AddErrorToModel(model, "At least one team needs 10 points!");
            }
            return RedirectToAction("index", "RegisterMatch", model);
        }

        private void AddErrorToModel(ScoreFormModel model, string errorMsg)
        {
            model.ErrorMsg = errorMsg;
            model.WarningMsg = string.Empty;
        }

        private void AddWarningToModel(ScoreFormModel model, string warningMsg)
        {
            model.ErrorMsg = string.Empty;
            model.WarningMsg = warningMsg;
        }

        private bool LatestMatchIsIdentical(ScoreFormModel model)
        {
            var latestRegistredMatch = PresentationFactory.MatchService.AllMatches().OrderByDescending(m => m.PlayedAt).FirstOrDefault();
            if (latestRegistredMatch != null)
            {
                var firstTeam = new List<Guid> { model.Team1Player1, model.Team1Player2 };
                var secondTeam = new List<Guid> { model.Team2Player1, model.Team2Player2 };
                if ((firstTeam.Contains(latestRegistredMatch.Team1Player1) && firstTeam.Contains(latestRegistredMatch.Team1Player2) && model.Team1Score == latestRegistredMatch.Team1Score) ||
                    (secondTeam.Contains(latestRegistredMatch.Team1Player1) && secondTeam.Contains(latestRegistredMatch.Team1Player2) && model.Team2Score == latestRegistredMatch.Team1Score))
                {
                    if ((firstTeam.Contains(latestRegistredMatch.Team2Player1) && firstTeam.Contains(latestRegistredMatch.Team2Player2) && model.Team1Score == latestRegistredMatch.Team2Score) ||
                    (secondTeam.Contains(latestRegistredMatch.Team2Player1) && secondTeam.Contains(latestRegistredMatch.Team2Player2) && model.Team2Score == latestRegistredMatch.Team2Score))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}