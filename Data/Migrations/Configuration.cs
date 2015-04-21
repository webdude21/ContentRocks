namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;

    using Config;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models.Content;
    using Models.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<UnitOfWork>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UnitOfWork context)
        {
            var posts = context.Set<Post>();

            if (!posts.Any())
            {
                var dataGenerator = new ContentFactory(RandomDataGenerator.Instance);
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole(GlobalConstants.AdministratorRoleName));
                var author = new ApplicationUser { UserName = GlobalConstants.DefaultUser };
                userManager.Create(author, author.UserName);
                userManager.AddToRole(author.Id, GlobalConstants.AdministratorRoleName);
                var post = dataGenerator.GetRealisticPost();
                post.Author = author;
                posts.Add(post);
            }
        }
    }
}