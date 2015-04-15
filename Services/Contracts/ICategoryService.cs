namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface ICategoryService
    {
        IQueryable<Category> GetAllCategories();
    }
}