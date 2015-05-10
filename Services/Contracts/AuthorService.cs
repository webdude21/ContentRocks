﻿namespace Services.Contracts
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Models;
    using Models.Identity;

    public class AuthorService : IAuthorService
    {
        private readonly IDbSet<ApplicationUser> dataSet;

        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dataSet = this.unitOfWork.Set<ApplicationUser>();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.dataSet;
        }

        public ApplicationUser GetBy(string username)
        {
            return this.dataSet.FirstOrDefault(author => author.UserName == username);
        }

        public void DeleteBy(string id)
        {
            var entity = this.dataSet.Find(id);
            Checker.CheckForNull(entity, "entity");
            this.dataSet.Remove(entity);
            this.SaveChanges();
        }

        private void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}