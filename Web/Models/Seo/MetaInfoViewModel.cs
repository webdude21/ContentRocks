namespace Web.Models.Seo
{
    using System.Collections.Generic;

    using global::Models.SEO;

    using Web.Infrastructure.Mappings;

    public class MetaInfoViewModel : IMapFrom<MetaInfo>
    {
        public string Description { get; set; }

        public string FriendlyUrl { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public string Title { get; set; }
    }
}