namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Constants;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class AuthorController : BaseController
    {
        private readonly IPostService postService;

        public AuthorController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Detail(string username, int? page)
        {
            return this.View(this.postService
                .GetTheLatestPostsByAuthor(username, GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                .Project().To<PostViewModel>());
        }

        [ChildActionOnly]
        public ActionResult Pager(string username, int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel
                .ConvertFrom(this.postService.GetPager(page, this
                .postService.GetTheLatestPostsByAuthor(username))));
        }
    }
}