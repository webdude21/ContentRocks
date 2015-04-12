namespace Web.Models.Content
{
    using System;

    using global::Models.Content;

    using Web.Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public DateTime CommentedOn { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public string AuthorId { get; set; }
    }
}