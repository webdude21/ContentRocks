namespace Web.ViewModels
{
    using AutoMapper;

    using Models.Identity;

    using Web.Infrastructure.Mappings;

    public class AuthorViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public int PostsCount { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, AuthorViewModel>()
                .ForMember(sourceModel => sourceModel.PostsCount, result => result.MapFrom(fullModel => fullModel.Posts.Count));
        }
    }
}