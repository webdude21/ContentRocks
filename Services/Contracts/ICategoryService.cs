namespace Services.Contracts
{
    using Models.Content;

    public interface ICategoryService : IEntityService<Category>
    {
        void AddCategory(Category category);
    }
}