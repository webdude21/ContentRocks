namespace Web.Infrastructure.Constants
{
    public static class PostRoute
    {
        public const string DefaultController = Controllers.PostsController;

        public const string Name = "Posts";

        public const string UrlPattern = "{controller}/{id}-{friendlyUrl}";

        public const string Detail = Actions.Detail;
    }
}
