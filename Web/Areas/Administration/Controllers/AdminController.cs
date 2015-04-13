namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Config;

    using Web.Areas.Administration.Helpers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : Controller
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView("_AdminMenu", AdminMenu.Items);
        }
    }
}