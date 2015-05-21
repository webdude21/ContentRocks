namespace Web.Infrastructure.Identity
{
    using System.Security.Principal;

    using Data.Contracts;

    using Microsoft.AspNet.Identity;

    using Models.Identity;

    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity currentIdentity;

        private readonly IUnitOfWork unitOfWork;

        private ApplicationUser user;

        public CurrentUser(IIdentity identity, IUnitOfWork context)
        {
            this.currentIdentity = identity;
            this.unitOfWork = context;
        }

        public ApplicationUser Get()
        {
            return this.user ?? (this.user = this.unitOfWork.Set<ApplicationUser>().Find(this.currentIdentity.GetUserId()));
        }
    }
}