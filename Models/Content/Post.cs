namespace Models.Content
{
    using Models.SEO;

    public class Post : BaseModel
    {
        public DateStamp DateStamp { get; set; }

        public MetaInfo MetaInfo { get; set; }

        public string Title { get; set; }
    }
}