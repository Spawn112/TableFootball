namespace TableFootball.Website.Controllers.Pages
{
    using System.Web.Mvc;
    using TableFootball.Website.Models.Pages;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeModel();
            return View("/Views/Pages/Home.cshtml", model);
        }
    }
}