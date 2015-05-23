namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class PageController : BaseController
    {
        private readonly IPageService pageService;

        public PageController(IPageService pageService)
        {
            this.pageService = pageService;
        }

        public ActionResult Index(string friendlyUrl)
        {
            return this.View(Mapper.Map<PageViewModel>(this.pageService.GetBy(friendlyUrl)));
        }
    }
}