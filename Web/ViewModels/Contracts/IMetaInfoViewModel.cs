namespace Web.ViewModels.Contracts
{
    public interface IMetaInfoViewModel
    {
        string AllTags { get; }

        string MetaDescription { get; set; }

        string MetaTitle { get; set; }
    }
}