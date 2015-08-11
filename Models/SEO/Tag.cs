namespace Models.SEO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Content;

    public class Tag : BaseModel
    {
        private ICollection<Post> posts;

        public Tag()
        {
            this.posts = new HashSet<Post>();
        }

        [MaxLength(30)]
        public string Name { get; set; }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
            }
        }
    }
}