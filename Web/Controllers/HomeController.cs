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
        private const string HomePagePosts = "HomePagePosts";

        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
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

                this.HttpContext.Cache.Add(cacheKey, posts, null, DateTime.Now.AddHours(1), 
                    TimeSpan.Zero, CacheItemPriority.Default, null);
            }
            else
            {
                posts = (List<PostViewModel>)this.HttpContext.Cache[cacheKey];
            }

            return posts;
        }
    }
}