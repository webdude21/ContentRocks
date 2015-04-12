namespace Web.Models.Content
{
    using System;
    using System.Collections.Generic;

    using global::Models.Content;

    using Web.Infrastructure.Mappings;
    using Web.Models.Seo;

    public class PostViewModel : IMapFrom<Post>
    {
        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public DateTime CreatedOn { get; set; }

        public MetaInfoViewModel MetaInfo { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }
    }
}