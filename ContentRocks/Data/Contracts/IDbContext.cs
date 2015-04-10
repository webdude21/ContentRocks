namespace Data.Contracts
{
    using System.Data.Entity;

    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        int SaveChanges();
    }
}