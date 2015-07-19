namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class SettingsController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}