namespace Web.Infrastructure
{
    using Models.Content;
    using System.Collections.Generic;
    using System.Web;

    public interface IImageUploader
    {
        void UploadImages(HttpRequestBase request, HttpServerUtilityBase serverUtility, ICollection<Image> images);

        void DeleteImagesFromFileSystem(List<Image> imagesToDelete, HttpServerUtilityBase server);
    }
}
