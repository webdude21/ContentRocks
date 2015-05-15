
namespace Web.Infrastructure.Constants
{
    using Config;

    public static class ImageRoute
    {
        public const string DefaultController = Controllers.Images;

        public const string Detail = Actions.GetImage;

        public const string FileNameMatcher = @"\S+";

        public const string Name = "Images";

        public static string UrlPattern = GlobalConstants.PostImagesRelativePath.Substring(1) + "{fileName}";
    }
}
