namespace TableFootball.Website.Controllers.Pages
{
    using System.Web.Mvc;
    using TableFootball.Website.Models.Pages;

    public class GameHistoryController : Controller
    {
        public ActionResult Index()
        {
            var model = new GameHistoryModel();
            return View("/Views/Pages/GameHistory.cshtml", model);
        }
    }
}