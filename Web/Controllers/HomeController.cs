namespace Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using AutoMapper;

    using Web.Infrastructure.Cache;
    using Web.ViewModels.Content;

    public class HomeController : BaseController
    {
        private readonly ICacheService cacheService;

        public HomeController(ICacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public ActionResult Index()
        {
            var homePosts = this.cacheService.HomePosts;
            return this.View(Mapper.Map<IEnumerable<PostViewModel>>(homePosts));
        }
    }
}