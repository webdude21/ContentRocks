namespace Common.Contracts
{
    using Models.Content;

    public interface IContentFactory
    {
        Post GetPost(int id);

        Category GetCategory(int id);
    }
}