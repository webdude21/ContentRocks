namespace Models.SEO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [NotMapped]
    public class MetaInfo
    {
        private ICollection<Tag> tags;

        public MetaInfo()
        {
            this.tags = new HashSet<Tag>();
        }

        public string Description { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }

        public string Title { get; set; }
    }
}