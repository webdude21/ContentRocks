namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Areas.Administration.ViewModels.Content;
    using Web.Infrastructure.Constants;
    using Web.ViewModels.Content;

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

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        // GET: Administration/Posts/Create
        public ActionResult Create([Bind(Include = PostCreateViewModel.ModelBinderProperties)] PostCreateViewModel post)
        {
            if (ModelState.IsValid)
            {
                this.postService.AddPost(PostCreateViewModel.GetPostFrom(post));
                return this.RedirectToAction(Actions.Index);
            }

            return this.View();
        }

    }
}