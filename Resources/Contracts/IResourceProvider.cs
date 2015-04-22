namespace Resources.Contracts
{
    public interface IResourceProvider
    {
        object GetResource(string name, string culture);
    }
}