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

            routes.MapRoute(PostRoute.Name, PostRoute.UrlPattern,
                new { controller = PostRoute.DefaultController, action = PostRoute.Detail },
                new { id = PostRoute.IdMatcher, friendlyUrl = PostRoute.FriendlyUrlMatcher },
                new[] { Assemblies.NoAreaControllersNamespace });

            routes.MapRoute(DefaultRoute.Name, DefaultRoute.UrlPattern,
                new {
                        controller = DefaultRoute.DefaultController,
                        action = DefaultRoute.DefaultAction,
                        id = UrlParameter.Optional
                    },
                new[] { Assemblies.NoAreaControllersNamespace });
        }
    }
}