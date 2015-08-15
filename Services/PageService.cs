namespace Services
{
    using System.Data.Entity;

    using Data.Contracts;

    using Models.Content;

    using Contracts;

    public class PageService : FriendlyUrlService<Page>,  IPageService
    {
        private IDbSet<Page> pages;

        public PageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.pages = unitOfWork.Set<Page>();
        }
    }
}