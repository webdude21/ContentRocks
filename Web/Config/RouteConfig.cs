namespace Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Web.Infrastructure.Constants;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                DefaultRoute.Name,
                DefaultRoute.RouteMatcher,
                new { controller = DefaultRoute.DefaultController, action = DefaultRoute.DefaultAction, id = UrlParameter.Optional });
        }
    }
}