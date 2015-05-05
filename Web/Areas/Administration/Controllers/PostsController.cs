namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Areas.Administration.ViewModels.Content;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;
    using Config;
    using Common;

    public class PostsController : AdminController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService, ICurrentUser user)
            : base(user)
        {
            this.postService = postService;
        }

        // GET: Administration/Posts
        public ActionResult Index(int? page)
        {
            return this.View(this.postService
                        .GetTheLatestPosts(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
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
            if (this.ModelState.IsValid)
            {
                post.Author = this.CurrentUser.Get();
                this.postService.AddPost(PostCreateViewModel.GetPostFrom(post));
                return this.RedirectToAction(Actions.Index);
            }

            return this.View();
        }

    }
}