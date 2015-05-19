namespace Web.Controllers
{
    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using System.Linq;
    using System.Web.Mvc;

    using Web.Infrastructure.Constants;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class PostsController : BaseController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Detail(int id, string friendlyUrl)
        {
            return this.View(this.postService.GetBy(id, friendlyUrl).Project().To<PostViewModel>().FirstOrDefault());
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.postService
                        .GetTheLatestPosts(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
        }

        [ChildActionOnly]
        public ActionResult Pager(int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel.ConvertFrom(this.postService.GetPager(page)));
        }
    }
}