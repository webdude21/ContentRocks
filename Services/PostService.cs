namespace Services
{
    using System.Linq;

    using Common;

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

        public void AddPost(Post newPost)
        {
            Validator.CheckForNull(newPost, "newPost");
            this.CheckIfEntityExists(newPost.Id);
            this.DataSet.Add(newPost);
            this.SaveChanges();
        }
    }
}