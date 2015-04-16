namespace Common.Contracts
{
    using Models.Content;

    public interface IContentFactory
    {
        Category GetCategory(int id);

        Post GetPost(int id);
    }
}