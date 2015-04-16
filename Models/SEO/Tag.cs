namespace Models.SEO
{
    using System.ComponentModel.DataAnnotations;

    public class Tag : BaseModel
    {
        [MaxLength(30)]
        public string Name { get; set; }
    }
}