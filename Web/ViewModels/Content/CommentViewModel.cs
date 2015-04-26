namespace Web.ViewModels.Content
{
    using System;

    using Models.Content;

    using Web.Infrastructure.Mappings;

    public class CommentViewModel : BaseViewModel, IMapFrom<Comment>
    {
        public string AuthorId { get; set; }

        public DateTime CommentedOn { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }
    }
}