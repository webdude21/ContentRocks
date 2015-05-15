namespace Web.Controllers
{
    using AutoMapper;
    using Services.Contracts;
    using System.Web.Mvc;
    using Web.ViewModels.Content;

    public class ImagesController : BaseController
    {
        private IImageService imageService;

        public ImagesController(IImageService imageService) : base()
        {
            this.imageService = imageService;
        }

        public ActionResult GetImage(string fileName)
        {
            var image = Mapper.Map<ImageViewModel>(this.imageService.GetBy(fileName));
            return this.File(Server.MapPath("~" + image.Url), image.MimeType, image.FileName);
        }
    }
}