namespace Config
{
    public static class GlobalConstants
    {
        public const string AdministratorRoleName = "Admin";

        public const string SecurityToken = "ContentRocks CMS";

        public static readonly string ConnectionString = ApplicationSettings.Default.ConnectionName;

        public static readonly int PageSize = ApplicationSettings.Default.PageSize;

        public static readonly string SiteName = ApplicationSettings.Default.Name;

        public static readonly string HomeAdvert = ApplicationSettings.Default.HomeAdvert;

        public static readonly int HomePostsCacheTimeInHours = (int)ApplicationSettings.Default.HomePostsCacheTimeInHours;

        public const string DefaultUserName = "webdude";

        public const int HomePagePostsCount = 6;

        public const int HomePagePostsPerRow = 3;

        public const int HomePagePostsCharLimit = 300;

        public const string Credits = "Powered by ContentRocks";

        public const string GitHubLink = "https://github.com/webdude21/ContentRocks";

        public const string RobotsIndexFollow = "index, follow";

        public const string DateTimeFormat = "{0:MM/dd/yyyy HH:MM:ss}";

        public const string DateFormat = "{0:MM/dd/yyyy}";

        public const string DigitsOnly = @"\d+";

        public const string FriendlyUrlsRegex = @"[a-zA-ZА-Я-а-я0-9]+";

        public const string DefaultLoginEmail = "webdude@webdude.eu";

        public const string UserNameRegex = @"[\w]+";

        public const string PostImagesRelativePath = "/Content/UploadedFiles/";
    }
}