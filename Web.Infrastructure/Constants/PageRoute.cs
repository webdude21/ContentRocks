namespace Web.Infrastructure.Constants
{
    using Config;

    public static class PageRoute
    {
        public const string DefaultController = Controllers.Pages;

        public const string Detail = Actions.Detail;

        public const string FriendlyUrlMatcher = GlobalConstants.FriendlyUrlsRegex;

        public const string Name = "Pages";

        public const string UrlPattern = "{friendlyUrl}";
    }
}