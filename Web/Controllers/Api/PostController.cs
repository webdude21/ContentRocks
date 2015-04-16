namespace Web.Controllers.Api
{
    using System.Linq;
    using System.Web.Http;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Models.Content;

    public class PostController : ApiController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.Ok(this.postService.GetTheLatestPosts().Project().To<PostViewModel>().ToList());
        }
    }
}