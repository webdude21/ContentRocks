namespace Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using AutoMapper;

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
            return this.View(Mapper.Map<CategoryViewModel>(this.categoryService.GetBy(id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            var categoryToUpdate = this.categoryService.GetBy(categoryViewModel.Id);
            this.TryUpdateModel(categoryToUpdate);
            
            if (this.ModelState.IsValid)
            {
                this.categoryService.Update();
                return this.RedirectToAction(Actions.Index);
            }

            return this.View(categoryViewModel);
        }

        // GET: Administration/Category
        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }
    }
}