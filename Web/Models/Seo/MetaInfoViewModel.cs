namespace Web.Models.Seo
{
    using System.Collections.Generic;

    using global::Models.SEO;

    using Web.Infrastructure.Mappings;

    public class MetaInfoViewModel : IMapFrom<MetaInfo>
    {
        public string Description { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }
    }
}