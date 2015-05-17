namespace Web.Infrastructure
{
    using Models.Content;
    using System.Collections.Generic;
    using System.Web;

    public interface IFileUploader
    {
        void UploadFiles(HttpRequestBase request, HttpServerUtilityBase serverUtility);

        void DeleteFilesFromFileSystem(List<FileInfo> imagesToDelete, HttpServerUtilityBase server);
    }
}
