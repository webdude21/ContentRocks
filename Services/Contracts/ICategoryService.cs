namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface ICategoryService
    {
        void AddCategory(Category category);

        IQueryable<Category> GetAllCategories();
    }
}