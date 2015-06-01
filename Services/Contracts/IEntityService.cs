namespace Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IEntityService<T> : IService
    {
        T Add(T entity);

        void DeleteBy(int id);

        IQueryable<T> GetAll();

        T GetBy(int id);

        int GetPageCount(int pageSize);

        Pager GetPager(int? currentPage);

        Pager GetPager(int? currentPage, IQueryable<T> query);

        IQueryable<T> GetWithPaginating(int count, int page = 1);

        void Update();

        void DeleteAll();
    }
}