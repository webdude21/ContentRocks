namespace Services
{
    using System.Linq;

    using Common;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(IUnitOfWork dbContext)
            : base(dbContext)
        {
        }

        public void AddPost(Post newPost)
        {
            Validator.CheckForNull(newPost, "newPost");
            this.CheckIfEntityExists(newPost.Id);
            this.DataSet.Add(newPost);
            this.SaveChanges();
        }

        public IQueryable<Post> GetTheLatestPosts()
        {
            return this.DataSet.OrderByDescending(post => post.CreatedOn);
        }

        public IQueryable<Post> GetTheLatestPosts(int count, int page = 0)
        {
            return this.GetDataWithPaging(this.GetTheLatestPosts(), count, page);
        }
    }
}