namespace Services.Contracts
{
    using Models.Content;

    public interface IPageService : IEntityService<Page>, IFriendlyUrlService<Page>
    {
    }
}