namespace Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Services.Contracts;

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
            return this.View();
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            return this.View();
        }

    }
}