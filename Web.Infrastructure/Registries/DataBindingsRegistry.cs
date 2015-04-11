namespace Web.Infrastructure.Registries
{
    using System.Data.Entity;

    using Data;
    using Data.Contracts;

    using Ninject;

    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(typeof(IDbSet<>)).To(typeof(DbSet<>));
            kernel.Bind<IDbContext>().To<UnitOfWork>();
        }
    }
}