namespace Models.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Contracts;
    using Models.SEO;

    public class Page : AuthoredContent, IFriendlyUrl, IMetaInfo
    {
        private ICollection<Tag> tags;

        public Page()
        {
            this.tags = new HashSet<Tag>();
        }

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