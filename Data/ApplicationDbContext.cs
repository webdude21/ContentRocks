namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Config;

    using Data.Contracts;
    using Data.Migrations;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Contracts;
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

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        private void ApplyAuditInfoRules()
        {
            var addedOrModifiedEntries =
                this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified)));

            // Approach via @julielerman: http://bit.ly/123661P
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

        private void ApplyDeletableEntityRules()
        {
            var deletedEntries = this.ChangeTracker.Entries()
                    .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted));

            foreach (var entry in deletedEntries)
            {
                MarkAsDeleted(entry);
            }
        }

        private static void MarkAsDeleted(DbEntityEntry entry)
        {
            var entity = (IDeletableEntity)entry.Entity;
            entity.DeletedOn = DateTime.UtcNow;
            entity.IsDeleted = true;
            entry.State = EntityState.Modified;
        }
    }
}