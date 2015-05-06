namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Config;

    using Data.Contracts;
    using Data.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Contracts;
    using Models.Identity;

    public class UnitOfWork : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public UnitOfWork() : base(GlobalConstants.ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UnitOfWork, Configuration>());
        }

        public static UnitOfWork Create()
        {
            return new UnitOfWork();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            var addedOrModifiedEntries = this.ChangeTracker.Entries().Where(e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            foreach (var entry in addedOrModifiedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}