namespace Models.SEO
{
    using System.Collections.Generic;

    public class MetaInfo
    {
        public string Description { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public string Title { get; set; }
    }
}