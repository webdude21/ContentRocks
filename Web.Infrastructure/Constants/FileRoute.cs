
namespace Web.Infrastructure.Constants
{
    public static class FileRoute
    {
        public const string DefaultController = Controllers.FileDownload;

        public const string Detail = Actions.GetFile;

        public const string FileNameMatcher = @"\S+";

        public const string Name = "Files";

        public static string UrlPattern = "{url}";
    }
}
