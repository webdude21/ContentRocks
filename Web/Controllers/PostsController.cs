namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Models.Content;

    public class PostsController : BaseController
    {
        public PostsController(IPostService postService)
        {
            this.PostService = postService;
        }

        public IPostService PostService { get; set; }

        public ActionResult Index()
        {
            return this.View(this.PostService.GetTheLatestPosts().Project().To<PostViewModel>().ToList());
        }

        public ActionResult Detail(int id, string friendlyUrl)
        {
            return this.View(this.PostService.GetPostBy(id, friendlyUrl).Project().To<PostViewModel>().FirstOrDefault());
        }
    }
}