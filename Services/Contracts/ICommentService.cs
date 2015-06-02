namespace Services.Contracts
{
    using System.Linq;

    using Models.Content;

    public interface ICommentService : IEntityService<Comment>
    {
        IQueryable<Comment> GetLatestComments(int postId, int count, int page = 1);

        IQueryable<Comment> GetLatestComments(int postId);
    }
}