namespace Models.Contracts
{
    using System.Collections.Generic;

    using Models.SEO;

    public interface IMetaInfo
    {
        string MetaDescription { get; set; }

        string MetaTitle { get; set; }

        ICollection<Tag> Tags { get; set; }
    }
}