namespace Models.Content
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Config;

    using Models.Contracts;

    public class Category : AuthoredContent, IFriendlyUrl
    {
        private ICollection<Post> posts;

        public Category()
        {
            this.posts = new HashSet<Post>();
        }

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

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegex)]
        public string FriendlyUrl { get; set; }
    }
}