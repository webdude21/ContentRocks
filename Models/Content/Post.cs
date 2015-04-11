namespace Models.Content
{
    using Models.Identity;
    using Models.SEO;

    public class Post : BaseModel
    {
        public DateStamp DateStamp { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public MetaInfo MetaInfo { get; set; }

        public string Title { get; set; }
    }
}