namespace Web
{
    using System.Web.Http;

    using Web.Infrastructure.Constants;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                DefaultApiRoute.Name,
                DefaultApiRoute.RouteMatcher,
                new { id = RouteParameter.Optional });
        }
    }
}