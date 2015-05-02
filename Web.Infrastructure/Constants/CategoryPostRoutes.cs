namespace Web.Infrastructure.Constants
{
    using Config;

    public class CategoryPostRoute
    {
        public const string DefaultController = Controllers.Posts;

        public const string Detail = Actions.Detail;

        public const string FriendlyUrlMatcher = GlobalConstants.FriendlyUrlsRegex;

        public const string Name = "CategoryPost";

        public const string UrlPattern = "{category}/{friendlyUrl}";
    }
}