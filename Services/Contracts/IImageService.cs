
namespace Services.Contracts
{
    using Models.Content;

    public interface IImageService : IEntityService<Image>
    {
        Image GetBy(string filename);
    }
}
