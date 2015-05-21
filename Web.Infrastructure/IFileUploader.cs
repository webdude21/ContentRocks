namespace Web.Infrastructure
{
    using System.Collections.Generic;
    using System.Web;

    using Models.Content;

    public interface IFileUploader
    {
        void DeleteFile(int id);

        void DeleteFilesFromFileSystem(List<FileEntity> imagesToDelete);

        FileEntity SaveFile(HttpPostedFile file);

        void UploadFiles(HttpRequestBase request);

        void DeleteAllFiles();
    }
}