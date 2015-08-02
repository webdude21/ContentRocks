namespace Services
{
    using Common;

    using Data.Contracts;

    using Models.Content;

    using Contracts;

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
    }
}