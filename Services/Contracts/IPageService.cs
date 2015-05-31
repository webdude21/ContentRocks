namespace Services.Contracts
{
    using Models.Content;

    public interface IPageService : IEntityService<Page>, IFriendlyUrlService<Page>
    {
        Page GetByWithTags(string friendlyUrl);
    }
}