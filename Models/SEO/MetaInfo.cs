namespace Models.SEO
{
    using System.Collections.Generic;

    public class MetaInfo : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}