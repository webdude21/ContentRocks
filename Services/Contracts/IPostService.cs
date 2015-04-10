namespace Services.Contracts
{
    using System.Linq;

    using Models;

    public interface IPostService
    {
        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page);
    }
}