﻿namespace Services
{
    using System.Linq;

    using Data.Contracts;

    using Models.Content;

    using Services.Contracts;

    public class FileService : BaseService<FileEntity>, IFileUploadService
    {
        public FileService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public FileEntity GetBy(string url)
        {
            return this.DataSet.FirstOrDefault(file => file.Url == url);
        }
    }
}