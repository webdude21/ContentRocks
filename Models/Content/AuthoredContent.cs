namespace Models.Content
{
    using System;

    using Models.Contracts;
    using Models.Identity;

    public abstract class AuthoredContent : BaseModel, IAuditInfo
    {
        public virtual ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }
    }
}