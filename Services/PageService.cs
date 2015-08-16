namespace Services
{
    using Data.Contracts;

    using Models.Content;

    using Contracts;

    public class PageService : FriendlyUrlService<Page>, IPageService
    {
        public PageService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}