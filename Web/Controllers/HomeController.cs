namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Config;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class HomeController : BaseController
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        public ActionResult Index()
        {
            return this.View(this.postService.GetTheLatestPosts(GlobalConstants.HomePagePostsCount)
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
        }
    }
}