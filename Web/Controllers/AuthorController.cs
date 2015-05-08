namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class AuthorController : BaseController
    {
        private IPostService postService;

        public AuthorController(IPostService postService)
        {
            this.postService = postService;
        }

        public ActionResult Detail(string authorId)
        {
            return this.View(this.postService.GetTheLatestPostsByAuthor(authorId).Project().To<PostViewModel>());
        }
    }
}