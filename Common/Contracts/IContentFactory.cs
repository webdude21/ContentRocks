namespace Common.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface IContentFactory
    {
        Category GetCategory(int id);

        Post GetPost(int id);

        IQueryable<Post> GetPosts(int count);
    }
}