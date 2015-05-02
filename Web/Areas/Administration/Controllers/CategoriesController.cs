namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.ViewModels.Content;

    public class CategoriesController : AdminController
    {
        private ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: Administration/Categories
        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAllCategories().Project().To<CategoryViewModel>().ToList());
        }
    }
}