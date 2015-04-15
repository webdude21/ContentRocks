namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface IPostService : IService
    {
        void AddPost(Post getPost);

        IQueryable<Post> GetTheLatestPosts();

        IQueryable<Post> GetTheLatestPosts(int count, int page = 1);
    }
}