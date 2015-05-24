namespace Models.Contracts
{
    using System.Collections.Generic;

    using Models.SEO;

    public interface IMetaInfo
    {
        ICollection<Tag> Tags { get; set; }

        string MetaDescription { get; set; }

        string MetaTitle { get; set; }
    }
}