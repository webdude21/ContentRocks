namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface IPostService : IEntityService<Post>
    {
        void AddPost(Post newPost);

        Post GetBy(int id, string friendlyUrl);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page = 1);

        IQueryable<Post> GetTheLatestPostsByAuthor(string username, int count, int page = 1);

        IQueryable<Post> GetTheLatestPostsByAuthor(string username);
    }
}