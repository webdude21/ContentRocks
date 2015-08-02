namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Infrastructure.Constants;
    using Infrastructure.Filters;
    using Infrastructure.Identity;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class CommentsController : AdminController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICurrentUser user, ICommentService commentService)
            : base(user)
        {
            this.commentService = commentService;
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.commentService.GetLatestComments(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<CommentViewModel>()
                        .ToList());
        }

        [ChildActionOnly]
        public ActionResult Pager(int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel.ConvertFrom(this.commentService.GetPager(page)));
        }

        [HttpDelete]
        [VerifyAjaxRequest]
        public ActionResult Delete(int id)
        {
            this.commentService.DeleteBy(id);
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}