﻿namespace Web.Infrastructure.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;

    using Models.Content;
    using Config;
    using Services.Contracts;

    public class ImageUploader : IImageUploader
    {
        private IImageService imageService;

        public ImageUploader(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public void UploadImages(HttpRequestBase request, HttpServerUtilityBase serverUtility)
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
                var fileTosave = new Image
                {
                    FileName = originalFileName,
                    Url = relativePath + resultFileName,
                    MimeType = fileBase.ContentType
                };

                this.imageService.Add(fileTosave);
                var postedFileBase = fileBase;
                postedFileBase.SaveAs(Path.Combine(pathToSave, resultFileName));
            }
        }

        public void DeleteImagesFromFileSystem(List<Image> imagesToDelete, HttpServerUtilityBase server)
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