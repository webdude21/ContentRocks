namespace Models
{
    using Models.Identity;

    public class AuthoredContent : BaseModel
    {
        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }
    }
}