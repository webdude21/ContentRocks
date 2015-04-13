namespace Data.Contracts
{
    using System.Data.Entity;

    public interface IUnitOfWork
    {
        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;
    }
}