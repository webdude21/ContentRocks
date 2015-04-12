namespace Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Common;

    using Models.Content;

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
                var dataGenerator = new DataGenerator(RandomDataGenerator.Instance);
                posts.Add(dataGenerator.GetPost(1));
            }
        }
    }
}