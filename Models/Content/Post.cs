namespace Models.Content
{
    using System;
    using System.Collections.Generic;

    using Models.Contracts;
    using Models.SEO;

    public class Post : AuthoredContent, IAuditInfo
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
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

        public MetaInfo Seo { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime PostedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public string Title { get; set; }
    }
}