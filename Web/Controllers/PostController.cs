namespace Web.Controllers
{
    using System.Web.Http;

    using Services.Contracts;

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
            return this.Ok(this.postService.GetTheLatestPosts());
        }
    }
}