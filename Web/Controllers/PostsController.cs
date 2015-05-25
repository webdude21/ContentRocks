﻿namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Constants;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class PostsController : BaseController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [OutputCache(Duration = GlobalConstants.CacheDuration, VaryByParam = "friendlyUrl")]
        public ActionResult Detail(string friendlyUrl)
        {
            return this.View(Mapper.Map<PostViewModel>(this.postService.GetBy(friendlyUrl)));
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.postService.GetTheLatestPosts(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
        }

        [ChildActionOnly]
        public ActionResult Pager(int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel.ConvertFrom(this.postService.GetPager(page)));
        }
    }
}