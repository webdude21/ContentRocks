namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface IPostService : IService
    {
        void AddPost(Post newPost);

        IQueryable<Post> GetPostBy(int id);

        IQueryable<Post> GetPostBy(int id, string friendlyUrl);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page = 1);
    }
}