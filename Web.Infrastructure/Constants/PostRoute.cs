namespace Web.Infrastructure.Constants
{
    public static class PostRoute
    {
        public const string DefaultController = Controllers.Posts;

        public const string Name = "Posts";

        public const string UrlPattern = "{controller}/{id}_{friendlyUrl}";

        public const string Detail = Actions.Detail;
    }
}
