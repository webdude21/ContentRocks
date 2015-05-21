namespace Models.Content
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Models.Contracts;

    public class FileEntity : BaseModel, IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        [MaxLength(200)]
        public string FileName { get; set; }

        [MaxLength(50)]
        public string MimeType { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }
    }
}