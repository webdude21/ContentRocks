namespace Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Config;

    using Data.Contracts;

    using Models;

    using Services.Contracts;

    public abstract class BaseService<T> : IEntityService<T> where T : BaseModel
    {
        private readonly IDbSet<T> dataSet;

        private IUnitOfWork unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this.dataSet = unitOfWork.Set<T>();
        }

        protected IDbSet<T> DataSet
        {
            get
            {
                return this.dataSet;
            }
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "The UnitOfWork shouldn't be null");
                }

                this.unitOfWork = value;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DataSet;
        }

        public IQueryable<T> GetBy(int id)
        {
            return this.DataSet.Where(entity => entity.Id == id);
        }

        public int GetPageCount(int pageSize)
        {
            return (this.DataSet.Count() + pageSize - 1) / pageSize;
        }

        public Pager GetPager(int? currentPage)
        {
            return new Pager
                       {
                           TotalPages = this.GetPageCount(GlobalConstants.PageSize),
                           CurrentPage = Checker.GetValidPageNumber(currentPage)
                       };
        }

        protected virtual void CheckIfEntityExists(object id)
        {
            if (this.dataSet.Find(id) != null)
            {
                throw new ArgumentException("Duplicate Ids aren't allowed.");
            }
        }

        protected virtual IQueryable<T> GetDataWithPaging(IQueryable<T> data, int count, int page)
        {
            return data.Skip((page - 1) * count).Take(count);
        }

        protected virtual void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }

        public void DeleteBy(int id)
        {
            var entity = this.dataSet.Find(id);
            Checker.CheckForNull(entity, "entity");
            this.DataSet.Remove(entity);
            this.SaveChanges();
        }
    }
}