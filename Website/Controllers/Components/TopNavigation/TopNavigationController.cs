namespace TableFootball.Website.Controllers.Components.TopNavigation
{
    using System.Web.Mvc;
    using TableFootball.Website.Models.Components.TopNavigation;

    public class TopNavigationController : Controller
    {
        public ActionResult Index()
        {
            var model = new TopNavigationModel();
            return PartialView("/Views/Components/TopNavigation/TopNavigation.cshtml", model);
        }
    }
}