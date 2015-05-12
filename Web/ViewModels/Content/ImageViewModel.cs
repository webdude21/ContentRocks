namespace Web.ViewModels.Content
{
    using System.ComponentModel.DataAnnotations;

    public class ImageViewModel : BaseViewModel
    {
        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(50)]
        public string MimeType { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }

        public virtual PostViewModel Post { get; set; }

        public int PostId { get; set; }
    }
}