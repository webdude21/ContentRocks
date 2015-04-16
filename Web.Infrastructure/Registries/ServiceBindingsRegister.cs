namespace Web.Infrastructure.Registries
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    using Services.Contracts;

    public class ServiceBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(
                k =>
                k.FromAssemblyContaining<IService>()
                    .SelectAllClasses()
                    .BindAllInterfaces()
                    .Configure(b => b.InRequestScope()));
        }
    }
}