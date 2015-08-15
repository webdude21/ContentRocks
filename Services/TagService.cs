namespace Services
{
    using Contracts;
    using Data.Contracts;
    using Models.Content;
    using Models.SEO;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    class TagService : ITagService
    {
        private IDbSet<Tag> tags;

        public TagService(IUnitOfWork unitOfWork)
        {
            this.tags = unitOfWork.Set<Tag>();
        }

        public void AddTagsToPost(Post post, IEnumerable<string> tagNamesToAdd)
        {
            foreach (var tagName in tagNamesToAdd)
            {
                var tagToAddToThePost = this.FindOrCreateTag(tagName);
                post.Tags.Add(tagToAddToThePost);
            }
        }

        private Tag FindOrCreateTag(string name)
        {
            var tag = this.tags.FirstOrDefault(t => t.Name == name);

            if (tag == null)
            {
                tag = new Tag { Name = name };
            }

            return tag;
        }
    }
}
