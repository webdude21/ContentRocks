namespace Web.ViewModels.Seo
{
    using System.ComponentModel.DataAnnotations;

    using Models.SEO;

    using Infrastructure.Mappings;
    using AutoMapper;

    public class TagViewModel : IMapFrom<Tag>, IHaveCustomMappings
    {
        [MaxLength(30)]
        public string Name { get; set; }

        public int PostsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Tag, TagViewModel>()
                 .ForMember(sourceModel => sourceModel.PostsCount, result => result.MapFrom(fullModel => fullModel.Post.Count));
        }
    }
}