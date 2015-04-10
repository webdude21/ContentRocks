namespace Services.Contracts
{
    using System.Linq;

    using Models;

    internal interface IPostService
    {
        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count);

        IQueryable<Post> GetTheLatestPosts(int count, int page);
    }
}