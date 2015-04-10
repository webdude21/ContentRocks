namespace Models
{
    using Models.SEO;

    public class Post : BaseModel
    {
        public string Title { get; set; }

        public MetaInfo MetaInfo { get; set; }

        public DateStamp DateStamp { get; set; }
    }
}