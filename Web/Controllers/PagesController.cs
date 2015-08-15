namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Services.Contracts;

    using Infrastructure.Cache;
    using Infrastructure.Constants;
    using ViewModels.Content;

    public class PagesController : BaseController
    {
        private readonly ICacheService cacheService;

        private readonly IPageService pageService;

        public PagesController(ICacheService cacheService, IPageService pageService)
        {
            this.cacheService = cacheService;
            this.pageService = pageService;
        }

        public ActionResult Detail(string friendlyUrl)
        {
            return this.View(Mapper.Map<PageViewModel>(this.pageService.GetBy(friendlyUrl)));
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            return this.PartialView(Partials.PagesMenu, Mapper.Map<IEnumerable<PageViewShortModel>>(this.cacheService.GetAllPages));
        }
    }
}