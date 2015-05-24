namespace Config
{
    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";

        public const string Credits = "Powered by ContentRocks";

        public const string DateFormat = "{0:MM/dd/yyyy}";

        public const string DateTimeFormat = "{0:MM/dd/yyyy HH:MM:ss}";

        public const string DefaultLoginEmail = "webdude@webdude.eu";

        public const string DefaultUserName = "webdude";

        public const string DigitsOnly = @"\d+";

        public const string FriendlyUrlsRegex = @"[a-zA-ZА-Я-а-я0-9]+";

        public const string GitHubLink = "https://github.com/webdude21/ContentRocks";

        public const int HomePagePostsCharLimit = 317;

        public const int HomePagePostsCount = 6;

        public const int HomePagePostsPerRow = 3;

        public const string PostedFilesRelativePath = "/Content/UploadedFiles/";

        public const string RobotsIndexFollow = "index, follow";

        public const string SecurityToken = "ContentRocks CMS";

        public const string UserNameRegex = @"[\w]+";

        public static readonly string ConnectionString = ApplicationSettings.Default.ConnectionName;

        public static readonly string HomeAdvert = ApplicationSettings.Default.HomeAdvert;

        public static readonly int HomePostsCacheTimeInHours = (int)ApplicationSettings.Default.HomePostsCacheTimeInHours;

        public static readonly int PageSize = ApplicationSettings.Default.PageSize;

        public static readonly string SiteName = ApplicationSettings.Default.Name;
    }
}