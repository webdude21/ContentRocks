namespace Web.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Hosting;

    using Models.Content;
    using Config;
    using Services.Contracts;

    public class FileUploader : IFileUploader
    {
        private readonly IFileUploadService fileService;

        public FileUploader(IFileUploadService fileService)
        {
            this.fileService = fileService;
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

        public void DeleteFilesFromFileSystem(List<FileEntity> imagesToDelete)
        {
            var pathsToDelete = imagesToDelete.Where(image => image.Url.Contains(GlobalConstants.PostedFilesRelativePath))
                    .Select(image => HostingEnvironment.MapPath("~" + image.Url))
                    .Where(File.Exists);

            foreach (var pathToDelete in pathsToDelete)
            {
                File.Delete(pathToDelete);
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