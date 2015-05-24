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

        private readonly IPageService pageService;

        public MemoryCacheService(IPostService postService, IPageService pageService)
        {
            this.postService = postService;
            this.pageService = pageService;
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

        public IList<Page> GetAllPages
        {
            get
            {
                return this.Get<IList<Page>>(CacheConstants.AllPages, () => this
                    .pageService
                    .GetAll()
                    .ToList());
            }
        }
    }
}