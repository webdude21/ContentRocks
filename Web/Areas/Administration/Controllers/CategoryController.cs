namespace Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Services.Contracts;

    using Web.Infrastructure.Identity;
    using Web.ViewModels.Content;

    public class CategoryController : AdminController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService, ICurrentUser user)
            : base(user)
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
            throw new NotImplementedException();
        }

        // GET: Administration/Category
        public ActionResult Index()
        {
            return this.View(this.categoryService.GetAll().Project().To<CategoryViewModel>().ToList());
        }
    }
}