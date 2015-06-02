namespace Web.ViewModels.Content
{
    using AutoMapper;

    using Models.Content;

    using Web.Infrastructure.Mappings;

    public class CommentViewModel : BaseViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public string Content { get; set; }

        public int PostId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                  .ForMember(
                      sourceModel => sourceModel.AuthorName,
                      result => result.MapFrom(fullModel => fullModel.Author.UserName))
                  .ForMember(
                      sourceModel => sourceModel.AuthorId,
                      result => result.MapFrom(fullModel => fullModel.Author.Id));
        }
    }
}