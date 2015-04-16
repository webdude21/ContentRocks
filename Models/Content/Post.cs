namespace Models.Content
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Models.Contracts;
    using Models.SEO;

    public class Post : AuthoredContent, IFriendlyUrl
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        public virtual Category Category { get; set; }

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
        [RegularExpression(ModelConstants.FriendlyUrlsRegexValidator,
            ErrorMessage = ModelConstants.FriendlyUrlsValidatorErrorMessage)]
        public string FriendlyUrl { get; set; }

        public MetaInfo MetaInfo { get; set; }

        public DateTime? PostedOn { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }
    }
}