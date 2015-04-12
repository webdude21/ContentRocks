﻿namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Models;
    using Web.Models.Content;

    public class PostsController : Controller
    {
        public IPostService PostService { get; set; }

        public PostsController(IPostService postService)
        {
            this.PostService = postService;
        }

        public ActionResult Index()
        {
            return this.View(this.PostService.GetTheLatestPosts().Project().To<PostViewModel>().ToList());
        }
    }
}