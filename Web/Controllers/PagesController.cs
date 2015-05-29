namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.UI;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Cache;
    using Web.Infrastructure.Constants;
    using Web.ViewModels.Content;

    public class PagesController : BaseController
    {
        private readonly IPageService pageService;

        public PagesController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        public ActionResult Detail(string friendlyUrl)
        {
            return this.View(Mapper.Map<PageViewModel>(this.pageService.GetBy(friendlyUrl)));
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView(Partials.PagesMenu, this.pageService.GetAll().Project().To<PageViewShortModel>());
        }
    }
}