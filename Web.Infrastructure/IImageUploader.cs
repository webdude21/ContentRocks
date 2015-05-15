namespace Web.Infrastructure
{
    using Models.Content;
    using System.Collections.Generic;
    using System.Web;

    public interface IImageUploader
    {
        void UploadImages(HttpRequestBase request, HttpServerUtilityBase serverUtility);

        void DeleteImagesFromFileSystem(List<Image> imagesToDelete, HttpServerUtilityBase server);
    }
}
