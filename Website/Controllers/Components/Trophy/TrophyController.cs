namespace TableFootball.Website.Controllers.Components.Trophy
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TableFootball.Website.Models.Components.Trophy;

    public class TrophyController : Controller
    {
        public ActionResult Index()
        {
            var trophies = PresentationFactory.TrophyService.AllTrophies();
            var model = new List<TrophyModel>();
            var allPlayers = PresentationFactory.PlayerService.AllPlayers();
            foreach (var trophy in trophies)
            {
                model.Add(new TrophyModel() { Name = trophy.Name, Value = trophy.Value, Players = allPlayers.Where(p => trophy.Players.Contains(p.ID)) });
            }
            return PartialView("/Views/Components/Trophy/Trophy.cshtml", model);
        }
    }
}