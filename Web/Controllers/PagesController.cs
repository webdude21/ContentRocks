namespace Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using Services.Contracts;

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
    }
}