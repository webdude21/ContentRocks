namespace Data
{
    using System.Data.Entity;

    using Config;

    using Data.Contracts;
    using Data.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Identity;

    public class UnitOfWork : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public UnitOfWork() : base(GlobalConstants.ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UnitOfWork, Configuration>());
        }

        public static UnitOfWork Create()
        {
            return new UnitOfWork();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}