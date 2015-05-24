namespace Web.Infrastructure.Cache
{
    using System.Collections.Generic;
    using System.Linq;

    using Config;

    using Models.Content;

    using Services.Contracts;

    using Web.Infrastructure.Constants;

    public class MemoryCacheService : BaseCacheService, ICacheService
    {
        private readonly IPostService postService;

        public MemoryCacheService(IPostService postService)
        {
            this.postService = postService;
        }

        public IList<Post> HomePosts
        {
            get
            {
                return this.Get<IList<Post>>(CacheConstants.HomePagePosts, () => this
                    .postService
                    .GetTheLatestPosts(GlobalConstants.HomePagePostsCount)
                    .ToList());
            }
        }
    }
}