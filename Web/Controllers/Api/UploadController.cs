namespace Web.Controllers.Api
{
    using System.Web;
    using System.Web.Http;

    using Infrastructure;
    using Infrastructure.Constants;

    [Authorize]
    public class UploadController : ApiController
    {
        private readonly IFileUploader fileUploader;

        public UploadController(IFileUploader fileUploader)
        {
            this.fileUploader = fileUploader;
        }

        [HttpPost]
        public IHttpActionResult Upload()
        {
            var file = HttpContext.Current.Request.Files[0];
            var savedFile = this.fileUploader.SaveFile(file);
            return this.CreatedAtRoute(FileRoute.Name, new { area = string.Empty, url = savedFile.Url }, savedFile);
        }
    }
}