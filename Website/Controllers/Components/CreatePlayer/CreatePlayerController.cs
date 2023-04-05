namespace TableFootball.Website.Controllers.Components.CreatePlayer
{
    using System.Web.Mvc;
    using TableFootball.Datatypes.Entities;
    using TableFootball.Website.Models.Components.CreatePlayer;

    public class CreatePlayerController : Controller
    {
        public ActionResult Index()
        {
            var model = new CreatePlayerModel();
            return PartialView("/Views/Components/CreatePlayer/CreatePlayer.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlayer(CreatePlayerModel model)
        {
            PresentationFactory.PlayerService.CreatePlayer(new Player(model.Name));
            return RedirectToAction("index", "Home");
        }
    }
}