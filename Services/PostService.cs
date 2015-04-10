namespace Services
{
    using System.Linq;

    using Data.Contracts;

    using Models;

    using Services.Contracts;

    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Post> GetTheLatestPosts()
        {
            return this.DataSet.OrderByDescending(post => post.DateStamp.CreatedOn);
        }

        public IQueryable<Post> GetTheLatestPosts(int count, int page = 0)
        {
            return this.GetDataWithPaging(this.GetTheLatestPosts(), count, page);
        }
    }
}