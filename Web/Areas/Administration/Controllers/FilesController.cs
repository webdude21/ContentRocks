namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Areas.Administration.ViewModels.Content;
    using Web.Infrastructure;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Identity;
    using Web.ViewModels;

    public class FilesController : AdminController
    {
        private readonly IFileUploader fileUploader;

        private readonly IFileUploadService fileUploadService;

        public FilesController(IFileUploadService fileUploadService, ICurrentUser user, IFileUploader fileUploader)
            : base(user)
        {
            this.fileUploadService = fileUploadService;
            this.fileUploader = fileUploader;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (!this.Request.IsAjaxRequest())
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            this.fileUploader.DeleteFile(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public ActionResult DeleteAll()
        {
            if (!this.Request.IsAjaxRequest())
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            this.fileUploader.DeleteAllFiles();
            return this.JavaScript("window.location = '/'");
        }

        [HttpGet]
        public ActionResult Index(int? page = 1)
        {
            return
                this.View(
                    this.fileUploadService.GetWithPaginating(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<FileEntityViewModel>()
                        .ToList());
        }

        [ChildActionOnly]
        public ActionResult Pager(int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel.ConvertFrom(this.fileUploadService.GetPager(page)));
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return this.View();
        }
    }
}