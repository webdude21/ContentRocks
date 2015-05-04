namespace Web.Infrastructure.Registries
{
    using System.Security.Principal;
    using System.Web;

    using Ninject;
    using Ninject.Web.Common;

    using Web.Infrastructure.Identity;

    public class IdentityRegistry : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<IIdentity>().ToMethod(context => HttpContext.Current.User.Identity).InRequestScope();
            kernel.Bind<ICurrentUser>().To<CurrentUser>().InRequestScope();
        }
    }
}