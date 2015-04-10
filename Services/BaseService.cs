namespace Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    public abstract class BaseService<T>
        where T : class
    {
        private readonly IDbSet<T> dataSet;

        private IDbContext dbContext;

        protected BaseService(IDbContext dbContext)
        {
            this.DbContext = dbContext;
            this.dataSet = dbContext.Set<T>();
        }

        protected IDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "The dbContext shouldn't be null");
                }
                this.dbContext = value;
            }
        }

        protected IDbSet<T> DataSet
        {
            get
            {
                return this.dataSet;
            }
        }

        protected virtual IQueryable<T> GetDataWithPaging(IQueryable<T> data, int count, int page)
        {
            return data.Skip(page * count).Take(count);
        }
    }
}