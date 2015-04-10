namespace Data
{
    using System.Data.Entity;

    using Data.Contracts;
    using Data.Migrations;

    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}