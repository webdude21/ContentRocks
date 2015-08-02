namespace Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    using Models.Content;

    using Infrastructure.Constants;
    using Infrastructure.Validators;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(AuthorRoute.Name, AuthorRoute.UrlPattern,
            new { controller = AuthorRoute.DefaultController, action = AuthorRoute.Detail },
            new { },
            new[] { Assemblies.NoAreaControllersNamespace });

            routes.MapRoute(PostRoute.Name, PostRoute.UrlPattern,
                new { controller = PostRoute.DefaultController, action = PostRoute.Detail },
                new { friendlyUrl = new FriendlyUrlValidator<Post>() },
                new[] { Assemblies.NoAreaControllersNamespace });

            routes.MapRoute(PageRoute.Name, PageRoute.UrlPattern,
                new { controller = PageRoute.DefaultController, action = PageRoute.Detail },
                new { friendlyUrl = new FriendlyUrlValidator<Page>() },
                new[] { Assemblies.NoAreaControllersNamespace });

            routes.MapRoute(DefaultRoute.Name, DefaultRoute.UrlPattern,
                new { controller = DefaultRoute.DefaultController,
                    action = DefaultRoute.DefaultAction,
                    id = UrlParameter.Optional },
                new[] { Assemblies.NoAreaControllersNamespace });

            routes.MapRoute(FileRoute.Name, FileRoute.UrlPattern,
                 new { controller = FileRoute.DefaultController, action = Actions.GetFile },
                 new { url = FileRoute.FileNameMatcher });
        }
    }
}