namespace Services
{
    using System.Data.Entity;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class PageService : FriendlyUrlService<Page>,  IPageService
    {
        public PageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.Pages = unitOfWork.Set<Page>();
        }

        public IDbSet<Page> Pages { get; set; }
    }
}