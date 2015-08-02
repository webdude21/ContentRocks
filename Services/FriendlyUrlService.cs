namespace Services
{
    using System.Linq;

    using Data.Contracts;

    using Models;
    using Models.Contracts;

    using Contracts;

    public class FriendlyUrlService<T> : BaseService<T>, IFriendlyUrlService<T> where T : BaseModel, IFriendlyUrl
    {
        public FriendlyUrlService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public T GetBy(string friendlyUrl)
        {
            return this.DataSet.FirstOrDefault(p => p.FriendlyUrl == friendlyUrl);
        }

        public bool UrlExists(string friendlyUrl)
        {
            return this.DataSet.Any(url => url.FriendlyUrl == friendlyUrl);
        }
    }
}