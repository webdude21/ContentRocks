namespace Web.Infrastructure
{
    using System.Web;

    using Models.Content;

    public interface IFileStorage
    {
        void DeleteFile(int id);

        FileEntity SaveFile(HttpPostedFile file);

        void UploadFiles(HttpRequestBase request);

        void DeleteAllFiles();
    }
}