namespace Services.Contracts
{
    using Models.Content;
    using System.Collections.Generic;

    public interface ITagService
    {
        void AddTagsToPost(Post post, IEnumerable<string> tagNamesToAdd);
    }
}
