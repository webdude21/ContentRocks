namespace Services
{
    using Data.Contracts;
    using Models.Content;
    using Services.Contracts;
    using System.Data.Entity;
    using System.Linq;

    class ImageService : BaseService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Image GetBy(string filename)
        {
            return this.DataSet.FirstOrDefault(file => file.FileName == filename);
        }
    }
}
