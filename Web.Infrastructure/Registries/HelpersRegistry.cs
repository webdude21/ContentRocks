namespace Web.Infrastructure.Registries
{
    using Ninject;
    using Ninject.Web.Common;

    using Web.Infrastructure.Helpers;

    class HelpersRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IImageUploader>().To<ImageUploader>().InRequestScope();
        }
    }
}
