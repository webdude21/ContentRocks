namespace Web.Infrastructure.Constants
{
    using Config;

    public static class PostRoute
    {
        public const string DefaultController = Controllers.Posts;

        public const string Detail = Actions.Detail;

        public const string FriendlyUrlMatcher = GlobalConstants.FriendlyUrlsRegex;

        public const string IdMatcher = @"\d+";

        public const string Name = "Posts";

        public const string UrlPattern = "posts/{id}_{friendlyUrl}";
    }
}