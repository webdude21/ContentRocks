namespace Services
{
    using System.Linq;

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
    }
}