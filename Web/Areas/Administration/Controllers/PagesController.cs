namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common;

    using Config;

    using Services.Contracts;

    using Web.Areas.Administration.ViewModels.Content;
    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Identity;
    using Web.ViewModels;
    using Web.ViewModels.Content;

    public class PagesController : AdminController
    {
        private readonly IPageService pageService;

        public PagesController(IPageService pageService, ICurrentUser user)
            : base(user)
        {
            this.pageService = pageService;
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
                // this.pageService.Add(PageViewModel.GetPostFrom(post));
                // TODO Fix this shit
                return this.RedirectToAction(Actions.Index);
            }

            return this.View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            this.pageService.DeleteBy(id);
            return this.Json(string.Empty);
        }

        public ActionResult Edit(int id)
        {
            return this.View(Mapper.Map<PageViewModel>(this.pageService.GetBy(id)));
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PageViewModel pageViewModel)
        {
            var postToUpdate = this.pageService.GetBy(pageViewModel.Id);
            this.TryUpdateModel(postToUpdate);

            if (this.ModelState.IsValid)
            {
                this.pageService.Update();
                return this.RedirectToAction(Actions.Index);
            }

            return this.View(pageViewModel);
        }

        public ActionResult Index(int? page)
        {
            return this.View(this.pageService.GetWithPaginating(GlobalConstants.PageSize, Checker.GetValidPageNumber(page))
                        .Project()
                        .To<PageViewModel>()
                        .ToList());
        }

        [ChildActionOnly]
        public ActionResult Pager(int? page)
        {
            return this.PartialView(Partials.Pager, PagerViewModel.ConvertFrom(this.pageService.GetPager(page)));
        }
    }
}