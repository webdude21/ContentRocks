namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Config;

    using Web.Areas.Administration.Helpers;
    using Web.Controllers;
    using Infrastructure.Constants;
    using Infrastructure.Identity;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        public AdminController(ICurrentUser user)
        {
            this.CurrentUser = user;
        }

        protected ICurrentUser CurrentUser { get; set; }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView(Partials.AdminMenu, AdminMenu.Items);
        }
    }
}