namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Models.Content;

    using Services.Contracts;

    using Web.Infrastructure.Filters;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class CommentsController : AdminController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICurrentUser user, ICommentService commentService)
            : base(user)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        [VerifyAjaxRequest]
        public ActionResult Create(int id)
        {
            return this.PartialView(new CommentViewModel { PostId = id });
        }

        [HttpPost]
        [VerifyAjaxRequest]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            this.commentService.Add(new Comment { Content = comment.Content, Author = this.CurrentUser.Get(), PostId = comment.PostId });
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}