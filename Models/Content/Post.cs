namespace Models.Content
{
    using System.Collections.Generic;

    using Models.Contracts;

    public class Post : Page, IFriendlyUrl, IMetaInfo
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
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
    }
}