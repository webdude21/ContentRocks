namespace Services
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Data.Contracts;

    using Models.Content;
    using Models.SEO;

    using Contracts;

    public class TagService : ITagService
    {
        private readonly IDbSet<Tag> tags;

        public TagService(IUnitOfWork unitOfWork)
        {
            this.tags = unitOfWork.Set<Tag>();
        }

        public void UpdatePostTags(Post post, IEnumerable<string> tagNamesToAdd)
        {
            post.Tags.Clear();

            foreach (var tagName in tagNamesToAdd)
            {
                post.Tags.Add(this.FindOrCreateTag(tagName));
            }
        }

        private Tag FindOrCreateTag(string name)
        {
            return this.tags.FirstOrDefault(t => t.Name == name) ?? new Tag { Name = name };
        }
    }
}