namespace Models.Identity
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Content;

    public class ApplicationUser : IdentityUser
    {
        private readonly ICollection<Post> posts;

        public ApplicationUser()
        {
            this.posts = new HashSet<Post>();
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}