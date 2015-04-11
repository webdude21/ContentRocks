namespace Common.Contracts
{
    using Models.Content;

    public interface IDataGenerator
    {
        Post GetPost(int id);
    }
}