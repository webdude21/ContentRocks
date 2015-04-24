namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Models.Content;

    public class PostsController : AdminController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        // GET: Administration/Posts
        public ActionResult Index()
        {
            return this.View(this.postService.GetTheLatestPosts().Project().To<PostViewModel>().ToList());
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            return this.View();
        }

    }
}