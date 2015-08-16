namespace Services.Contracts
{
    using System.Collections.Generic;

    using Models.Content;

    public interface ITagService : IService
    {
        void UpdatePostTags(Post post, IEnumerable<string> tagNamesToAdd);
    }
}