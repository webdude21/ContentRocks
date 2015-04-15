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

        public IQueryable<Category> GetAllCategories()
        {
            return this.DataSet;
        }

        public void AddCategory(Category category)
        {
            Validator.CheckForNull(category, "category");
            this.CheckIfEntityExists(category.Id);
            this.DataSet.Add(category);
            this.SaveChanges();
        }
    }
}