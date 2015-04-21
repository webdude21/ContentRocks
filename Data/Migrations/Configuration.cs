namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;

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
                var author = new ApplicationUser { UserName = "webdude@webdude.eu" };
                userManager.Create(author, author.UserName);
                var post = dataGenerator.GetRealisticPost();
                post.Author = author;
                posts.Add(post);
            }
        }
    }
}