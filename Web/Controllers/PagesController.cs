namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

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
            return this.PartialView(Partials.PagesMenu, this.pageService.GetAll().Project().To<PageViewModel>().ToList());
        }
    }
}