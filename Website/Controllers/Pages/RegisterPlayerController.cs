namespace TableFootball.Website.Controllers.Pages
{
    using System.Web.Mvc;
    using TableFootball.Website.Models.Pages;

    public class RegisterPlayerController : Controller
    {
        public ActionResult Index()
        {
            var model = new RegisterPlayerModel();
            return View("/Views/Pages/RegisterPlayer.cshtml", model);
        }
    }
}