namespace Web.Infrastructure.Cache
{
    using System.Collections.Generic;

    using Models.Content;

    public interface ICacheService
    {
        IList<Post> HomePosts { get; }
    }
}