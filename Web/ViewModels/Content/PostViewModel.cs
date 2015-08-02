namespace Web.ViewModels.Content
{
    using System.Collections.Generic;

    using AutoMapper;

    using Models.Content;

    using Resources;

    using Infrastructure.Mappings;

    public class PostViewModel : PageViewModel, IMapFrom<Post>, IHaveCustomMappings
    {
        public string AuthorId { get; set; }

        public string AuthorName { get; set; }

        public CategoryViewModel Category { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public override string GetHtmlId
        {
            get
            {
                return "post-" + this.Id;
            }
        }

        public string PostedOnBy
        {
            get
            {
                return string.Format(Translation.PostedByOn, this.AuthorName, this.PostedOn);
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(
                    sourceModel => sourceModel.AuthorName,
                    result => result.MapFrom(fullModel => fullModel.Author.UserName))
                .ForMember(
                    sourceModel => sourceModel.AuthorId,
                    result => result.MapFrom(fullModel => fullModel.Author.Id));
        }
    }
}