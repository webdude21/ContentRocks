namespace Web.Infrastructure
{
    using Models.Content;
    using System.Collections.Generic;
    using System.Web;

    public interface IFileUploader
    {
        void UploadFiles(HttpRequestBase request);

        void DeleteFilesFromFileSystem(List<FileEntity> imagesToDelete);

        FileEntity SaveFile(HttpPostedFile file);

        void DeleteFile(int id);
    }
}
