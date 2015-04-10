namespace Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IPostService
    {
        void AddPost(Post getPost);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page);
    }
}