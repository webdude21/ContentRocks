namespace Web.Models.Contracts
{
    public interface IMetaInfoViewModel
    {
        string MetaDescription { get; set; }

        string MetaTitle { get; set; }

        string AllTags { get; }
    }
}
