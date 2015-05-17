namespace Services
{
    using Data.Contracts;
    using Models.Content;
    using Services.Contracts;
    using System.Data.Entity;
    using System.Linq;

    public class FileService : BaseService<FileEntity>, IFileUploadService
    {
        public FileService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public FileEntity GetBy(string filename)
        {
            return this.DataSet.FirstOrDefault(file => file.FileName == filename);
        }
    }
}
