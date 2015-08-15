namespace Services
{
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    using Models.Content;

    using Contracts;

    public class PostService : FriendlyUrlService<Post>, IPostService
    {
        private IDbSet<Category> categories;

        public PostService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.categories = unitOfWork.Set<Category>();
        }

        public void AddPost(Post newPost)
        {
            this.Add(newPost);
        }

        public Post GetBy(int id, string friendlyUrl)
        {
            return this.DataSet.FirstOrDefault(p => p.Id == id && p.FriendlyUrl == friendlyUrl);
        }

        public IQueryable<Post> GetTheLatestPosts()
        {
            return this.DataSet.OrderByDescending(post => post.CreatedOn);
        }

        public IQueryable<Post> GetTheLatestPosts(int count, int page = 1)
        {
            return this.GetDataWithPaging(this.GetTheLatestPosts(), count, page);
        }

        public IQueryable<Post> GetTheLatestPostsByAuthor(string username, int count, int page = 1)
        {
            return this.GetDataWithPaging(this.GetTheLatestPostsByAuthor(username), count, page);
        }

        public IQueryable<Post> GetTheLatestPostsByAuthor(string username)
        {
            return this.GetTheLatestPosts().Where(p => p.Author.UserName == username);
        }

        public override Post GetBy(string friendlyUrl)
        {
            return this.DataSet.Include("Tags").FirstOrDefault(post => post.FriendlyUrl == friendlyUrl);
        }
    }
}