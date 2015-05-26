namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.UI;

    using AutoMapper;

    using Config;

    using Services.Contracts;

    using Web.Infrastructure.Cache;
    using Web.Infrastructure.Constants;
    using Web.ViewModels.Content;

    public class PagesController : BaseController
    {
        private readonly ICacheService cacheService;

        private readonly IPageService pageService;

        public PagesController(ICacheService cacheService, IPageService pageService)
        {
            this.cacheService = cacheService;
            this.pageService = pageService;
        }

        [OutputCache(CacheProfile = GlobalConstants.CacheForAnHourOnTheServer)]
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