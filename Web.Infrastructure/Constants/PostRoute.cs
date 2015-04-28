namespace Web.Infrastructure.Constants
{
    public static class PostRoute
    {
        public const string DefaultController = Controllers.Posts;

        public const string Detail = Actions.Detail;

        public const string Name = "Posts";

        public const string UrlPattern = "Posts/{id}_{friendlyUrl}";
    }
}