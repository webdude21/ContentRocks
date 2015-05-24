namespace Models.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Contracts;
    using Models.SEO;

    public class Post : AuthoredContent, IFriendlyUrl, IMetaInfo
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        private ICollection<Tag> tags;

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }

        [MaxLength(200)]
        public string Title { get; set; }
    }
}