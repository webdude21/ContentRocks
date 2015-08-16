namespace Web.ViewModels.Seo
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Models.SEO;

    using Web.Infrastructure.Mappings;

    public class TagViewModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        [MaxLength(30)]
        public string Name { get; set; }

        public int PostsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagViewModel>()
                .ForMember(
                    sourceModel => sourceModel.PostsCount,
                    result => result.MapFrom(fullModel => fullModel.Posts.Count));
        }
    }
}