namespace Web.ViewModels.Content
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Models.Content;

    using Resources;

    using Web.Infrastructure.Mappings;

    public class CommentViewModel : BaseViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment", ResourceType = typeof(Translation))]
        public string Content { get; set; }

        public int PostId { get; set; }

        public string GetHtmlId => $"comment-{this.Id}";

        public string PostedOn => this.CreatedOn.ToLongDateString();

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