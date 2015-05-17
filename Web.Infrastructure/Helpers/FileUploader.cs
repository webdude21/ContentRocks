namespace Web.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Models.Content;
    using Config;
    using Services.Contracts;

    public class FileUploader : IFileUploader
    {
        private IFileUploadService fileService;

        public FileUploader(IFileUploadService fileService)
        {
            this.fileService = fileService;
        }

        public void UploadFiles(HttpRequestBase request, HttpServerUtilityBase serverUtility)
        {
            foreach (string upload in request.Files)
            {
                var httpPostedFileBase = request.Files[upload];
                if (httpPostedFileBase == null || httpPostedFileBase.ContentLength == 0)
                {
                    continue;
                }

                var relativePath = GlobalConstants.PostImagesRelativePath + DateTime.Now.ToString("dd-MM-yyyy/");
                var pathToSave = serverUtility.MapPath("~" + relativePath);

                this.MakeDirectoryIfNeeded(pathToSave);

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

        public void DeleteFilesFromFileSystem(List<FileEntity> imagesToDelete, HttpServerUtilityBase server)
        {
            var pathsToDelete = imagesToDelete.Where(image => image.Url.Contains(GlobalConstants.PostImagesRelativePath))
                    .Select(image => server.MapPath("~" + image.Url))
                    .Where(File.Exists);

            foreach (var pathToDelete in pathsToDelete)
            {
                File.Delete(pathToDelete);
            }
        }

        private void MakeDirectoryIfNeeded(string pathToSave)
        {
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
        }
    }
}