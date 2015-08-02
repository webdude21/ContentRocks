namespace Web.Areas.Administration
{
    using System.Web.Mvc;

    using Infrastructure.Constants;

    public class AdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_default",
                this.AreaName + "/" + DefaultRoute.UrlPattern,
                new { action = DefaultRoute.DefaultAction, id = UrlParameter.Optional });
        }
    }
}