namespace Services
{
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public void AddCategory(Category category)
        {
            Checker.CheckForNull(category, "category");
            this.CheckIfEntityExists(category.Id);
            this.DataSet.Add(category);
            this.SaveChanges();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return this.DataSet;
        }
    }
}