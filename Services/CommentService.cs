namespace Services
{
    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}