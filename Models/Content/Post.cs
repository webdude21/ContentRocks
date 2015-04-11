namespace Models.Content
{
    using System;

    using Models.Contracts;
    using Models.Identity;
    using Models.SEO;

    public class Post : BaseModel, IAuditInfo
    {
        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public MetaInfo MetaInfo { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}