﻿namespace Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Config;

    using Data.Contracts;

    using Models;

    using Contracts;

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

        public T Add(T entity)
        {
            Checker.CheckForNull(entity, "entity");
            var resultEntity = this.DataSet.Add(entity);
            this.SaveChanges();
            return resultEntity;
        }

        public void DeleteBy(int id)
        {
            var entity = this.DataSet.Find(id);
            Checker.CheckForNull(entity, "entity");
            this.DataSet.Remove(entity);
            this.SaveChanges();
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.DataSet;
        }

        public T GetBy(int id)
        {
            return this.DataSet.FirstOrDefault(entity => entity.Id == id);
        }

        public int GetPageCount(int pageSize)
        {
            return this.GetPageCount(pageSize, this.DataSet);
        }

        public Pager GetPager(int? currentPage)
        {
            return this.GetPager(currentPage, this.DataSet);
        }

        public Pager GetPager(int? currentPage, IQueryable<T> query)
        {
            return new Pager
                       {
                           TotalPages = this.GetPageCount(GlobalConstants.PageSize, query),
                           CurrentPage = Checker.GetValidPageNumber(currentPage)
                       };
        }

        public IQueryable<T> GetWithPaginating(int count, int page = 1)
        {
            return this.GetDataWithPaging(this.DataSet.OrderBy(entity => entity.Id), count, page);
        }

        public void Update()
        {
            this.SaveChanges();
        }

        public void DeleteAll()
        {
            foreach (var entity in this.DataSet)
            {
                this.DataSet.Remove(entity);
            }

            this.SaveChanges();
        }

        public int GetPageCount(int pageSize, IQueryable<T> query)
        {
            return (query.Count() + pageSize - 1) / pageSize;
        }

        public void Update(T entity)
        {
            this.DataSet.Attach(entity);
        }

        protected virtual void CheckIfEntityExists(object id)
        {
            if (this.DataSet.Find(id) != null)
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
    }
}