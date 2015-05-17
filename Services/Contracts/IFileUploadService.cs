
namespace Services.Contracts
{
    using Models.Content;

    public interface IFileUploadService : IEntityService<FileInfo>
    {
        FileInfo GetBy(string filename);
    }
}
