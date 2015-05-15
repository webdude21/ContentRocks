namespace Web.Areas.Administration.Controllers
{
    using Models.Content;
    using Services.Contracts;
    using System.Net;
    using System.Web.Mvc;
    using Web.Infrastructure;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class ImagesController : AdminController
    {
        private IImageService imageService;

        private IImageUploader imageUploader;

        public ImagesController(IImageService imageService, ICurrentUser user, IImageUploader imageUploader)
            : base(user)
        {
            this.imageService = imageService;
            this.imageUploader = imageUploader;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            this.imageService.DeleteBy(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage(Image model)
        {
            this.imageUploader.UploadImages(this.Request, this.Server);

            return null;
        }
    }
}