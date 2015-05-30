namespace Web.Infrastructure.Registries
{
    using Ninject;
    using Ninject.Web.Common;

    using Web.Infrastructure.Cache;
    using Web.Infrastructure.Helpers;

    public class HelpersRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IFileUploader>().To<FileUploader>().InRequestScope();
            kernel.Bind<ICacheService>().To<MemoryCacheService>().InRequestScope();
        }
    }
}