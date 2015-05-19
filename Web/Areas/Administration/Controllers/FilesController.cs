namespace Web.Areas.Administration.Controllers
{
    using System.Net;
    using System.Web.Mvc;

    using Services.Contracts;

    using Web.Infrastructure.Identity;

    public class FilesController : AdminController
    {
        private readonly IFileUploadService fileUploadService;

        public FilesController(IFileUploadService imageService, ICurrentUser user)
            : base(user)
        {
            this.fileUploadService = imageService;
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
    }
}