namespace Web.Areas.Administration
{
    using System.Web.Mvc;

    using Web.Infrastructure.Constants;

    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Administration";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_default",
                this.AreaName + "/" + DefaultRoute.UrlPattern,
                new { action = DefaultRoute.DefaultAction, id = UrlParameter.Optional });
        }
    }
}