namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Filters;
    using Web.ViewModels.Content;

    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        [VerifyAjaxRequest]
        public ActionResult Detail(int id)
        {
            return this.PartialView(Mapper.Map<CommentViewModel>(this.commentService.GetBy(id)));
        }

        [HttpGet]
        [VerifyAjaxRequest]
        public ActionResult GetCommentsForPost(int id, int? page)
        {
            return this.PartialView(this.commentService
                .GetLatestComments(id, GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                .Project()
                .To<CommentViewModel>()
                .ToList());
        }
    }
}