namespace Web.Infrastructure.Cache
{
    using System.Collections.Generic;

    using Data.Contracts;

    using Models.Content;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemoryCacheService(IUnitOfWork data)
        {
            this.unitOfWork = data;
        }

        public IList<Post> HomePosts
        {
            get
            {
                return this.Get<IList<Post>>("HomePagePosts", () => null);
            }
        }
    }
}