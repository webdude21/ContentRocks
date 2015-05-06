namespace Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IEntityService<out T> : IService
    {
        IQueryable<T> GetAll();

        T GetBy(int id);

        int GetPageCount(int pageSize);

        void DeleteBy(int id);

        Pager GetPager(int? currentPage);

        void Update();
    }
}