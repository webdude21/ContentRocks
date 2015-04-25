namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Models.Content;

    public class CategoryController : BaseController
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult DropdownList()
        {
            return this.View(this.categoryService.GetAllCategories().Project().To<CategoryViewModel>().ToList());
        }
    }
}