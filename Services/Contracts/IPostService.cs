namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface IPostService : IEntityService<Post>
    {
        void AddPost(Post newPost);

        IQueryable<Post> GetBy(int id, string friendlyUrl);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page = 1);
    }
}