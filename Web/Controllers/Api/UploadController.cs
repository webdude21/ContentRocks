namespace Web.Controllers.Api
{
    using System.Web;
    using System.Web.Http;

    using Infrastructure;
    using Infrastructure.Constants;

    [Authorize]
    public class UploadController : ApiController
    {
        private readonly IFileStorage fileUploader;

        public UploadController(IFileStorage fileUploader)
        {
            this.fileUploader = fileUploader;
        }

        [HttpPost]
        public IHttpActionResult Upload()
        {
            var savedFile = this.fileUploader.SaveFile(HttpContext.Current.Request.Files[0]);
            return this.CreatedAtRoute(FileRoute.Name, new { area = string.Empty, url = savedFile.Url }, savedFile);
        }
    }
}