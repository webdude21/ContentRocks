namespace Web.Areas.Administration.Controllers
{
    using Models.Content;
    using Services.Contracts;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Web.Infrastructure;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class FilesController : AdminController
    {
        private IFileUploadService fileUploadService;

        private IFileUploader imageUploader;

        public FilesController(IFileUploadService imageService, ICurrentUser user, IFileUploader imageUploader)
            : base(user)
        {
            this.fileUploadService = imageService;
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

            this.fileUploadService.DeleteBy(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFiles(HttpPostedFileBase file)
        {
            this.imageUploader.UploadFiles(this.Request, this.Server);
            return this.Json(string.Empty, JsonRequestBehavior.DenyGet);
        }
    }
}