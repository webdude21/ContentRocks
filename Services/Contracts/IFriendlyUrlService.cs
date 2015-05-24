namespace Services.Contracts
{
    public interface IFriendlyUrlService<out T>
    {
        T GetBy(string friendlyUrl);

        bool UrlExists(string friendlyUrl);
    }
}