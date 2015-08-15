namespace Services.Contracts
{
    using Models.Content;
    using System.Collections.Generic;

    public interface ITagService : IService
    {
        void AddTagsToPost(Post post, IEnumerable<string> tagNamesToAdd);
    }
}
