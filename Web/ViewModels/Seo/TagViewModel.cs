namespace Web.ViewModels.Seo
{
    using System.ComponentModel.DataAnnotations;

    using Models.SEO;

    using Web.Infrastructure.Mappings;

    public class TagViewModel : IMapFrom<Tag>
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}