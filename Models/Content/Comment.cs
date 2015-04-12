namespace Models.Content
{
    using System;

    public class Comment : AuthoredContent
    {
        public DateTime CommentedOn { get; set; }

        public string Content { get; set; }

        public virtual Post Post { get; set; }

        public int PostId { get; set; }

        public string Title { get; set; }
    }
}