namespace Services
{
    using System.Data.Entity;
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Models.Identity;

    using Contracts;

    public class AuthorService : IAuthorService
    {
        private readonly IDbSet<ApplicationUser> dataSet;

        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.dataSet = this.unitOfWork.Set<ApplicationUser>();
        }

        public void DeleteBy(string id)
        {
            var entity = this.dataSet.Find(id);
            Checker.CheckForNull(entity, "entity");
            this.dataSet.Remove(entity);
            this.SaveChanges();
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.dataSet;
        }

        public ApplicationUser GetBy(string username)
        {
            return this.dataSet.FirstOrDefault(author => author.UserName == username);
        }

        private void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }
    }
}