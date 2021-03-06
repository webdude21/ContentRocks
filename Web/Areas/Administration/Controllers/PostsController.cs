﻿namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using ViewModels.Content;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Filters;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class PostsController : AdminController
    {
        private readonly IPostService postService;

        private readonly ITagService tagService;

        public PostsController(IPostService postService, ITagService tagService, ICurrentUser user)
            : base(user)
        {
            this.postService = postService;
            this.tagService = tagService;
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
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

        [HttpDelete]
        [VerifyAjaxRequest]
        public ActionResult Delete(int id)
        {
            this.postService.DeleteBy(id);
            return this.Json(string.Empty);
        }

        [NullModelCheck("Post not found")]
        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<PostViewModel>(this.postService.GetBy(id)));
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PostViewModel postViewModel)
        {
            var postToUpdate = this.postService.GetBy(postViewModel.Id);

            if (postToUpdate.FriendlyUrl == postViewModel.FriendlyUrl)
            {
                this.ModelState["friendlyUrl"].Errors.Clear();
            }

            this.tagService.UpdatePostTags(postToUpdate, postViewModel.GetTagsAsStrings());
            this.TryUpdateModel(postToUpdate);

            if (this.ModelState.IsValid)
            {
                this.postService.Update();
                return this.RedirectToAction(Actions.Index);
            }

            return this.View(postViewModel);
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.postService.GetTheLatestPosts(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PostViewModel>()
                        .ToList());
        }
    }
}