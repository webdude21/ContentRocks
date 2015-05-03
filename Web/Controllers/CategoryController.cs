namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }

        [ChildActionOnly]
        public ActionResult DropdownList()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }

        public ActionResult Detail(int id)
        {
            return this.View(this.categoryService.GetBy(id).Project().To<CategoryWithPostsViewModel>().FirstOrDefault());
        }
    }
}