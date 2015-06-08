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
    using Models.Content;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Identity;

    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;

        private ICurrentUser CurrentUser { get; set; }

        public CommentsController(ICommentService commentService, ICurrentUser user)
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

        [HttpGet]
        [VerifyAjaxRequest]
        [Authorize]
        public ActionResult Create(int id)
        {
            return this.PartialView(new CommentViewModel { PostId = id });
        }

        [HttpPost]
        [VerifyAjaxRequest]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            var newComment = this.commentService.Add(new Comment { Content = comment.Content, Author = this.CurrentUser.Get(), PostId = comment.PostId });
            return this.RedirectToAction(Actions.Detail, Controllers.Comments, new { id = newComment.Id, area = string.Empty });
        }
    }
}