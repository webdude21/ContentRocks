namespace Config
{
    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";

        public static readonly string ConnectionString = ApplicationSettings.Default.ConnectionName;

        public static readonly int PageSize = ApplicationSettings.Default.PageSize;

        public static readonly string SiteName = ApplicationSettings.Default.Name;

        public const string Credits = "Powered by ContentRocks";

        public const string GitHubLink = "https://github.com/webdude21/ContentRocks";

        public const string RobotsIndexFollow = "index, follow";

        public const string DateTimeFormat = "{0:MM/dd/yyyy HH:MM:ss}";

        public const string DateFormat = "{0:MM/dd/yyyy}";

        public const string DigitsOnly = @"\d+";

        public const string FriendlyUrlsRegexValidator = @"[\w-]+";

        public const string GuidRegEx = @"\b[A-F0-9]{8}(?:-[A-F0-9]{4}){3}-[A-F0-9]{12}\b";
    }
}