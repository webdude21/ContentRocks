namespace Services
{
    using System.Linq;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public IQueryable<Comment> GetLatestCommentsForAPost(int postId, int count, int page = 1)
        {
            return this.GetDataWithPaging(this.GetLatestCommentsForAPost(postId), count, page);
        }

        public IQueryable<Comment> GetLatestCommentsForAPost(int postId)
        {
            return this.DataSet.Where(comment => comment.PostId == postId).OrderByDescending(comment => comment.CreatedOn);
        }

        public IQueryable<Comment> GetLatestComments(int count, int page = 1)
        {
            return this.GetDataWithPaging(this.DataSet.OrderByDescending(comment => comment.CreatedOn), count, page);
        }
    }
}