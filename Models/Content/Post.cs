namespace Models.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Models.Contracts;
    using Models.SEO;
    using Config;

    public class Post : AuthoredContent, IFriendlyUrl, IMetaInfo
    {
        private ICollection<Comment> comments;
        private ICollection<Tag> tags;

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

        [DataType(DataType.Html)]
        public string Content { get; set; }

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegexValidator)]
        public string FriendlyUrl { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

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
    }
}