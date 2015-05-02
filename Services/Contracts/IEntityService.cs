namespace Services.Contracts
{
    using System.Linq;

    public interface IEntityService<out T> : IService
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetBy(int id);
    }
}