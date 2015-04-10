namespace Data.Contracts
{
    using System.Data.Entity;

    public interface IDbContext
    {
        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;
    }
}