namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Services.Contracts;

    public class HomeController : Controller
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
            var something = this.postService.GetTheLatestPosts().ToList();
            return this.View();
        }
    }
}