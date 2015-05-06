namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Infrastructure.Constants;
    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class CategoryController : AdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService, ICurrentUser user) : base(user)
        {
            this.categoryService = categoryService;
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            this.categoryService.DeleteBy(id);
            return this.Json(string.Empty);
        }

        public ActionResult Edit(int id)
        {
            return this.View(this.categoryService.GetBy(id).Project().To<CategoryViewModel>().FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel category)
        {
            if (this.ModelState.IsValid)
            {
                return this.RedirectToAction(Actions.Index);
            }

            return this.View(category);
        }

        // GET: Administration/Category
        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }
    }
}