namespace Web.Areas.Administration.Controllers
{
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Services.Contracts;

    using Web.Infrastructure;
    using Web.Infrastructure.Identity;

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
            if (!this.Request.IsAjaxRequest())
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            this.fileUploadService.DeleteBy(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            this.imageUploader.UploadFiles(this.Request, this.Server);
            return this.Json(string.Empty, JsonRequestBehavior.DenyGet);
        }
    }
}