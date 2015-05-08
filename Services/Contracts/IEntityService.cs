namespace Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IEntityService<T> : IService
    {
        IQueryable<T> GetAll();

        T GetBy(int id);

        int GetPageCount(int pageSize);

        void DeleteBy(int id);

        Pager GetPager(int? currentPage);

        Pager GetPager(int? currentPage, IQueryable<T> query);

        void Update();
    }
}