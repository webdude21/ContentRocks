namespace Services
{
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class PageService : BaseService<Page>, IPageService
    {
        public PageService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.Pages = unitOfWork.Set<Page>();
        }

        public IDbSet<Page> Pages { get; set; }

        public Page GetBy(string friendlyUrl)
        {
            return this.Pages.FirstOrDefault(p => p.FriendlyUrl == friendlyUrl);
        }
    }
}