namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

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
            return this.View(this.postService.GetPostBy(id, friendlyUrl).Project().To<PostViewModel>().FirstOrDefault());
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.postService.GetTheLatestPosts(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
        }
    }
}