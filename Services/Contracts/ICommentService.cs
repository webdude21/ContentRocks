namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface ICommentService : IEntityService<Comment>
    {
        IQueryable<Comment> GetLatestCommentsForAPost(int postId, int count, int page = 1);

        IQueryable<Comment> GetLatestCommentsForAPost(int postId);

        IQueryable<Comment> GetLatestComments(int count, int page = 1);
    }
}