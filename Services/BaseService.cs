namespace Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    using Services.Contracts;

    public abstract class BaseService<T> : IService where T : class
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
                    throw new ArgumentNullException("value", "The dbContext shouldn't be null");
                }

                this.unitOfWork = value;
            }
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
            return data.Skip(page * count).Take(count);
        }

        protected virtual void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}