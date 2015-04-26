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

        [MaxLength(50)]
        [RegularExpression(GlobalConstants.FriendlyUrlsRegexValidator)]
        public string FriendlyUrl { get; set; }

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

        public string Title { get; set; }
    }
}