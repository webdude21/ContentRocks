namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

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
    }
}