namespace Web.Areas.Administration.Controllers
{
    using System.Net;
    using System.Web.Mvc;

    using Models.Content;

    using Services.Contracts;

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
        public ActionResult Create(int postId)
        {
            return this.PartialView(new CommentViewModel { PostId = postId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel comment)
        {
            if (!this.Request.IsAjaxRequest() && !this.ModelState.IsValid)
            {
                this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                this.HttpNotFound();
            }

            this.commentService.Add(new Comment { Content = comment.Content, Author = this.CurrentUser.Get(), PostId = comment.PostId });
            return this.Json(string.Empty, JsonRequestBehavior.AllowGet);
        }
    }
}