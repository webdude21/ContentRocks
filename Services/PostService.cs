namespace Services
{
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    using Models;

    using Services.Contracts;

    internal class PostService : BaseService<Post>, IPostService
    {

        public PostService(IDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Post> GetTheLatestPosts()
        {
            return this.DataSet.OrderByDescending(post => post.DateStamp.CreatedOn);
        }

        public IQueryable<Post> GetTheLatestPosts(int count)
        {
            return this.GetTheLatestPosts().Take(count);
        }

        public IQueryable<Post> GetTheLatestPosts(int count, int page)
        {
            return this.GetTheLatestPosts().Skip(page * count).Take(count);
        }
    }
}