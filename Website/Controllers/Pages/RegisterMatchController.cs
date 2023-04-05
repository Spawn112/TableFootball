namespace TableFootball.Website.Controllers.Pages
{
    using System.Web.Mvc;
    using TableFootball.Website.Models.Pages;

    public class RegisterMatchController : Controller
    {
        public ActionResult Index()
        {
            var model = new RegisterMatchModel();
            return View("/Views/Pages/RegisterMatch.cshtml", model);
        }
    }
}