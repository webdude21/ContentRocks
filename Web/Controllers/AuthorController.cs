namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Constants;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class AuthorsController : BaseController
    {
        private readonly IPostService postService;

        private readonly IAuthorService authorService;

        public AuthorsController(IPostService postService, IAuthorService authorService)
        {
            this.postService = postService;
            this.authorService = authorService;
        }

        public ActionResult Detail(string username, int? page)
        {
            return this.View(this.postService
                .GetTheLatestPostsByAuthor(username, GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                .Project().To<PostViewModel>().ToList());
        }

        public ActionResult Index()
        {
            return this.View(this.authorService.GetAll().Project().To<AuthorViewModel>().ToList());
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