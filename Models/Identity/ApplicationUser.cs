namespace Models.Identity
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Content;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Posts = new HashSet<Post>();
        }

        public virtual ICollection<Post> Posts { get; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            return await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}