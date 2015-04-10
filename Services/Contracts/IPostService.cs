namespace Services.Contracts
{
    using System.Linq;

    using Models;
    using Models.Content;

    public interface IPostService
    {
        void AddPost(Post getPost);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page);
    }
}