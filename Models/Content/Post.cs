namespace Models.Content
{
    using System;
    using System.Collections.Generic;

    using Models.SEO;

    public class Post : AuthoredContent
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

        public MetaInfo MetaInfo { get; set; }

        public DateTime? PostedOn { get; set; }

        public string Title { get; set; }
    }
}