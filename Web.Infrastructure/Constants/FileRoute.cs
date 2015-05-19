
namespace Web.Infrastructure.Constants
{
    using Config;

    public static class FileRoute
    {
        public const string DefaultController = Controllers.Files;

        public const string Detail = Actions.GetFile;

        public const string FileNameMatcher = @"\S+";

        public const string Name = "Files";

        public static string UrlPattern = GlobalConstants.PostedFilesRelativePath.Substring(1) + "{fileName}";
    }
}
