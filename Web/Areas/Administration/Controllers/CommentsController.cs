namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Models.Content;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Filters;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;
    using Config;
    using Common;

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
                        .To<PostViewModel>()
                        .ToList());
        }
    }
}