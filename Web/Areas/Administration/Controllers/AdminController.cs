namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Config;

    using Web.Areas.Administration.Helpers;
    using Web.Infrastructure.Constants;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView(Partials.AdminMenu, AdminMenu.Items);
        }
    }
}