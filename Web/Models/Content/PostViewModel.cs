namespace Web.Models.Content
{
    using System;
    using System.Collections.Generic;

    using global::Models.Content;

    using Web.Infrastructure.Mappings;
    using Web.Models.Seo;

    public class PostViewModel : BaseViewModel, IMapFrom<Post>
    {
        public ICollection<CommentViewModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? PostedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }
    }
}