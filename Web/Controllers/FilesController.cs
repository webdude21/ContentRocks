namespace Web.Controllers
{
    using AutoMapper;
    using Services.Contracts;
    using System.Web.Mvc;
    using Web.Infrastructure;
    using Web.ViewModels.Content;

    public class FilesController : BaseController
    {
        private IFileUploadService imageService;

        public FilesController(IFileUploadService imageService): base()
        {
            this.imageService = imageService;
        }

        public ActionResult GetFile(string fileName)
        {
            var image = this.imageService.GetBy(fileName);
            return this.File(Server.MapPath("~" + image.Url), image.MimeType, image.FileName);
        }
    }
}