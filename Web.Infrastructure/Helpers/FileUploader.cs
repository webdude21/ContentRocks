namespace Web.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Hosting;

    using Config;

    using Models.Content;

    using Services.Contracts;

    public class FileUploader : IFileUploader
    {
        private readonly IFileUploadService fileService;

        public FileUploader(IFileUploadService fileService)
        {
            this.fileService = fileService;
        }

        public void DeleteFile(int id)
        {
            this.DeleteFilesFromFileSystem(new List<FileEntity> { this.fileService.GetBy(id) });
            this.fileService.DeleteBy(id);
        }

        public void DeleteFilesFromFileSystem(List<FileEntity> filesToDelete)
        {
            var pathsToDelete =
                filesToDelete.Where(file => file.Url.Contains(GlobalConstants.PostedFilesRelativePath))
                    .Select(file => HostingEnvironment.MapPath("~" + file.Url))
                    .Where(File.Exists);

            foreach (var pathToDelete in pathsToDelete)
            {
                File.Delete(pathToDelete);
            }
        }

        public FileEntity SaveFile(HttpPostedFile file)
        {
            var relativePath = GlobalConstants.PostedFilesRelativePath + DateTime.Now.ToString("dd-MM-yyyy") + "/";
            var pathToSave = HostingEnvironment.MapPath("~" + relativePath);
            MakeDirectoryIfNeeded(pathToSave);

            var originalFileName = Path.GetFileName(file.FileName);
            var resultFileName = Guid.NewGuid() + "_" + originalFileName;
            var fileTosave = new FileEntity
                                 {
                                     FileName = originalFileName,
                                     Url = relativePath + resultFileName,
                                     MimeType = file.ContentType
                                 };

            this.fileService.Add(fileTosave);
            file.SaveAs(Path.Combine(pathToSave, resultFileName));

            return fileTosave;
        }

        public void UploadFiles(HttpRequestBase request)
        {
            foreach (string upload in request.Files)
            {
                var httpPostedFileBase = request.Files[upload];
                if (httpPostedFileBase == null || httpPostedFileBase.ContentLength == 0)
                {
                    continue;
                }

                var relativePath = GlobalConstants.PostedFilesRelativePath + DateTime.Now.ToString("dd-MM-yyyy");
                var pathToSave = HostingEnvironment.MapPath("~" + relativePath);

                MakeDirectoryIfNeeded(pathToSave);

                var fileBase = request.Files[upload];

                if (fileBase == null)
                {
                    continue;
                }

                var originalFileName = Path.GetFileName(fileBase.FileName);
                var resultFileName = Guid.NewGuid() + "_" + originalFileName;
                var fileTosave = new FileEntity
                                     {
                                         FileName = originalFileName,
                                         Url = relativePath + resultFileName,
                                         MimeType = fileBase.ContentType
                                     };

                this.fileService.Add(fileTosave);
                var postedFileBase = fileBase;
                postedFileBase.SaveAs(Path.Combine(pathToSave, resultFileName));
            }
        }

        private static void MakeDirectoryIfNeeded(string pathToSave)
        {
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
        }
    }
}