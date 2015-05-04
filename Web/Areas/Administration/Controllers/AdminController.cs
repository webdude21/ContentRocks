namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Config;

    using Web.Areas.Administration.Helpers;
    using Web.Infrastructure.Constants;
    using Web.Controllers;
    using Web.Infrastructure.Identity;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdminController : BaseController
    {
        protected ICurrentUser CurrentUser { get; set; }

        public AdminController(ICurrentUser user)
        {
            this.CurrentUser = user;
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView(Partials.AdminMenu, AdminMenu.Items);
        }
    }
}