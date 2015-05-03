namespace Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Caching;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Config;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class HomeController : BaseController
    {
        private readonly IPostService postService;

        private const string HomePagePosts = "HomePagePosts";

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
            return this.View(this.GetFromCache(HomePagePosts));
        }

        private List<PostViewModel> GetFromCache(string cacheKey)
        {
            List<PostViewModel> posts;

            if (this.HttpContext.Cache[cacheKey] == null)
            {
                posts = this.postService.GetTheLatestPosts(GlobalConstants.HomePagePostsCount)
                        .Project()
                        .To<PostViewModel>()
                        .ToList();

                this.HttpContext.Cache.Add(cacheKey, posts, null, DateTime.Now.AddHours(1), TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            else
            {
                posts = (List<PostViewModel>)this.HttpContext.Cache[cacheKey];
            }

            return posts;
        }
    }
}