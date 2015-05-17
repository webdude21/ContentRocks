
namespace Services.Contracts
{
    using Models.Content;

    public interface IFileUploadService : IEntityService<FileEntity>
    {
        FileEntity GetBy(string filename);
    }
}
