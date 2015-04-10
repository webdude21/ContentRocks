namespace Data
{
    using System.Data.Entity;

    using Config;

    using Data.Contracts;
    using Data.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Identity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ApplicationDbContext() : base(GlobalConstants.ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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