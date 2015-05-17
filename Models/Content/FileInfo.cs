namespace Models.Content
{
    using System.ComponentModel.DataAnnotations;

    public class FileInfo : BaseModel
    {
        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(50)]
        public string MimeType { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }
    }
}