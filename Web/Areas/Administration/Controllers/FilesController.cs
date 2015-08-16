namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Areas.Administration.ViewModels.Content;
    using Web.Infrastructure;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Filters;
    using Web.Infrastructure.Identity;
    using Web.ViewModels;

    public class FilesController : AdminController
    {
        private readonly IFileStorage fileUploader;

        private readonly IFileUploadService fileUploadService;

        public FilesController(IFileUploadService fileUploadService, ICurrentUser user, IFileStorage fileUploader)
            : base(user)
        {
            this.fileUploadService = fileUploadService;
            this.fileUploader = fileUploader;
        }

        [HttpDelete]
        [VerifyAjaxRequest]
        public ActionResult Delete(int id)
        {
            this.fileUploader.DeleteFile(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        [VerifyAjaxRequest]
        public ActionResult DeleteAll()
        {
            this.fileUploader.DeleteAllFiles();
            return this.JavaScript("window.location = '/'");
        }

        [HttpGet]
        public ActionResult Index(int? page = 1)
        {
            return this.View(this.fileUploadService.GetWithPaginating(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
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