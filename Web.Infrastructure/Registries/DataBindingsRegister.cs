namespace Web.Infrastructure.Registries
{
    using Data;
    using Data.Contracts;

    using Ninject;
    using Ninject.Web.Common;

    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}