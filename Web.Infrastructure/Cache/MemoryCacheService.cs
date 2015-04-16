namespace Web.Infrastructure.Cache
{
    using System.Collections.Generic;

    using Data.Contracts;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IUnitOfWork data;

        public MemoryCacheService(IUnitOfWork data)
        {
            this.data = data;
        }

        public IList<string> Countries
        {
            get
            {
                return this.Get<IList<string>>("Countries", () => null);
            }
        }
    }
}