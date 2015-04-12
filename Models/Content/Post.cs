namespace Models.Content
{
    using System;
    using System.Collections.Generic;

    using Models.Contracts;
    using Models.SEO;

    public class Post : AuthoredContent, IAuditInfo
    {
        private ICollection<Comment> comments;

        private ICollection<Tag> tags;

        public Post()
        {
            this.comments = new HashSet<Comment>();
            this.tags = new HashSet<Tag>();
        }

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

        public DateTime CreatedOn { get; set; }

        public Seo MetaInfo { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime PostedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

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

        public string Title { get; set; }
    }
}