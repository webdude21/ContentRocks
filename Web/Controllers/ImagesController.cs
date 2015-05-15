namespace Web.Controllers
{
    using AutoMapper;
    using Services.Contracts;
    using System.Web.Mvc;
    using Web.Infrastructure;
    using Web.ViewModels.Content;

    public class ImagesController : BaseController
    {
        private IImageService imageService;

        public ImagesController(IImageService imageService): base()
        {
            this.imageService = imageService;
        }

        public ActionResult GetImage(string fileName)
        {
            var image = this.imageService.GetBy(fileName);
            return this.File(Server.MapPath("~" + image.Url), image.MimeType, image.FileName);
        }
    }
}