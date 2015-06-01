namespace Models.Content
{
    public class Comment : AuthoredContent
    {
        public string Content { get; set; }

        public virtual Post Post { get; set; }

        public int PostId { get; set; }
    }
}