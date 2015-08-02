namespace Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using ViewModels.Content;

    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult Detail(int id)
        {
            return this.View(Mapper.Map<CategoryWithPostsViewModel>(this.categoryService.GetBy(id)));
        }

        [ChildActionOnly]
        public ActionResult DropdownList()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }

        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }
    }
}