namespace Web.Models.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using global::Models.Content;

    using Web.Infrastructure.Mappings;
    using Web.Models.Contracts;
    using Web.Models.Seo;

    public class PostViewModel : BaseViewModel, IMapFrom<Post>, IMetaInfoViewModel
    {
        public string AllTags
        {
            get
            {
                return string.Join(", ", this.Tags.Select(t => t.Name));
            }
        }

        public ICollection<CommentViewModel> Comments { get; set; }

        [DataType(DataType.Html)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? PostedOn { get; set; }

        public ICollection<TagViewModel> Tags { get; set; }

        public string Title { get; set; }
    }
}