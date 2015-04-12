namespace Web.Models.Seo
{
    using global::Models.SEO;

    using Web.Infrastructure.Mappings;

    public class TagViewModel : IMapFrom<Tag>
    {
        public string Name { get; set; }
    }
}