namespace Web.Infrastructure.Constants
{
    public static class AuthorRoute
    {
        public const string DefaultController = Controllers.Author;

        public const string Detail = Actions.Detail;

        public const string Name = "Authors";

        public const string UrlPattern = "author/{username}";
    }
}